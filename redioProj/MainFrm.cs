using DevComponents.DotNetBar;
using LZClient.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using NAudio;
using NAudio.Wave;

namespace redioProj
{
    public partial class MainFrm : OfficeForm
    {
        public MainFrm()
        {
            InitializeComponent();
            //获取配置信息
            //string ip = SysParam.CameraIP;
            //更新配置信息
            //SysParam.CameraIP = "192.168.100.158";
        }

        /// <summary>
        /// 关闭主窗口，保存最新的配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            SysParam.Save();
        }

        // tianxin
        private Socket tcpClient = null;//TCP句柄
        private Socket udpServes = null;//dup句柄
        private Thread thrUDPRecv;

        //6000000000/1000000=600个缓存
        static public Int16[] fft_wave = new Int16[1601 * 600];
        static public Int16[] fft_temp = new Int16[1601];
        //频谱最大值缓存
        static public int[] max_wave = new int[1601];

        //频谱图坐标偏移// 2022-11-22 11:16 
        static int window_left_offset = 40;
        static int window_top_offset = 60;

        //PCM播放器
        public struct pcm_stream
        {
            public WaveOut waveOut;
            public BufferedWaveProvider bufferedWaveProvider;//5s缓存区
        }
        pcm_stream pcm = new pcm_stream();

        //------------------------------------------------------------------------------------全局变量
        public struct app_define// 2022-11-22 15:26:10 guess:曲线信息
        {
            //记录绘图区域鼠标位置
            public int px;               //绘图区域点击的x坐标
            public int py;               //绘图区域点击的y坐标
            //
            public UInt64 center_freq;   //单频点分析中心频率
            public UInt64 ipan;          //单频点、频段扫描分析带宽
            public UInt64 start_freq;    //频段扫描开始频率
            public UInt64 stop_freq;     //频段扫描结束频率
            public UInt64 span;          //频段扫描每次上传的带宽数据
            //最大保持游标显示
            public double max_freq;      //最大保持频率
            public double max_dbuv;      //最大保持幅度
            public UInt64 max_index;     //最大保持在频谱的位置
            public double cursor_freq;   //鼠标选中点频率
            public double cursor_dbuv;   //鼠标点中点幅度
            //校准
            public UInt64 cal_index;     //校准频谱点的位置
            public double cal_freq;      //校准频谱点的频率
            public double cal_step;      //校准频谱点的递增
            //fft数据包统计&忙标记
            public int pack_count;       //用于计数频谱包个数
            public bool update;          //显示更新
        }
        app_define show = new app_define();// 2022-11-22 15:23:47

        //------------------------------------------------------------------------------------EM100接收机协议
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct common_header      //协议公共部分
        {
            public UInt32 header_magic_number;
            public UInt16 header_minor_version_numbe;
            public UInt16 header_major_version_number;
            public UInt16 header_sequence_number;
            public UInt16 header_reserved;
            public UInt32 data_size;
            public UInt16 attribute_tag;
            public UInt16 attribute_length;
            public Int16 trace_number_of_items;
            public byte trace_reserved;
            public byte trace_optional_header_length;
            public UInt32 trace_selector_flags;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct audio_option       //音频选项
        {
            public Int16 audio_mode;
            public Int16 frame_len;
            public UInt32 frequency_low;
            public UInt32 bandwidth;
            public UInt16 demodulation_id;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] demodulation_mode;
            public UInt32 frequency_high;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] reserved;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ifpan_option       //单频点选项
        {
            public UInt32 frequency_low;
            public UInt32 span_frequency;
            public Int16 reserved;
            public Int16 average_type;
            public UInt32 measure_time;
            public UInt32 frequency_high;
            public UInt32 selected_channel;
            public UInt32 demodulation_freq_low;
            public UInt32 demodulation_freq_high;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct pscan_option       //频段选项
        {
            public UInt32 StartFreq_low;
            public UInt32 StopFreq_low;
            public UInt32 StepFreq;
            public UInt32 StartFreq_high;
            public UInt32 StopFreq_high;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] reserved;
            public UInt64 timestamp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct audio_stream       //音频数据流
        {
            public common_header header;
            public audio_option option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12800)]
            public byte[] data;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ifpan_stream       //单频点数据流
        {
            public common_header header;
            public ifpan_option option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1601)]
            public Int16[] data;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct pscan_stream       //频段扫描数据流
        {
            public common_header header;
            public pscan_option option;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1601)]
            public Int16[] data;
        }




        private void delect_socket()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient.Dispose();
            }
            if (udpServes != null)
            {
                udpServes.Close();
                //udpClient.Dispose();
            }
            if (thrUDPRecv != null)
            {
                thrUDPRecv.Abort();
            }
        }

        //结构体与byte数组互相转换
        public static byte[] StructToBytes(object structure)
        {
            Int32 size = Marshal.SizeOf(structure);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, buffer, false);
                Byte[] bytes = new Byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        public static object BytesToStruct(byte[] bytes, Type strcutType) // 2022-11-24 17:10:04 解析数据包
        {// 2022-11-24 20:40:21 
            Int32 size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size); //通过使用指定的字节数,从进程的非托管内存中分配内存。
            try
            {
                // void Marshal.Copy(byte[] source, int startIndex, IntPtr destination, int length)
                Marshal.Copy(bytes, 0, buffer, size);// 将一维的托管8位无符号整数数组中的数据复制到非托管内存指针。
                // object Marshal.PtrToStructure(IntPtr ptr,Type structureType)
                return Marshal.PtrToStructure(buffer, strcutType); // 将数据从非托管内存块封送到新分配的指定类型的托管对象。
            }
            finally
            {
                Marshal.FreeHGlobal(buffer); // 释放以前从进程的非托管内存中分配的内存。
            }
        }


        private void UDPReceiveMessage(object obj)
        {
            //int ps = 0;
            while (true)
            {
                audio_stream audio = new audio_stream();
                ifpan_stream ifpan = new ifpan_stream();
                pscan_stream pscan = new pscan_stream();
                byte[] data = new byte[16384];
                int length = 0;

                //阻塞接收udp数据包 
                try
                {
                    // int Socket.Receive(byte[buffer) return The number of bytes received.
                    length = udpServes.Receive(data);// 2022-11-24 17:14:58 
                                                     //if (length == 3270)// 2022-11-24 22:01:36 
                                                     //    ps++;
                                                     //if (length == 12868)
                                                     //{
                                                     //    Console.WriteLine(ps);
                                                     //    Console.WriteLine(Marshal.SizeOf(audio));
                                                     //    ps = 0;
                                                     //}
                                                     //Console.WriteLine("udp数据包:"+length);
                                                     //Console.WriteLine(length);// 2022-11-24 16:57:37 length:3270|12868 
                }
                catch
                {
                    continue;
                }

                //音频数据包解析
                if (length == Marshal.SizeOf(audio))
                {

                    //单频点测量才播放声音
                    if (show.ipan <= 40000000)
                    {
                        try
                        {
                            audio = (audio_stream)BytesToStruct(data, typeof(audio_stream));
                            pcm.bufferedWaveProvider.AddSamples(audio.data, 0, 12800);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                //单频点数据包解析 // 2022-11-22 11:37 与下面 频段扫描数据包解析 有何区别
                if (length == Marshal.SizeOf(ifpan))
                {
                    //统计接收到的数据包
                    show.pack_count++;
                    //将收到的byte数据转换成结构体 // 2022-11-24 17:09:06 
                    ifpan = (ifpan_stream)BytesToStruct(data, typeof(ifpan_stream));
                    //得到中心频率
                    UInt64 frequency = ((UInt64)ifpan.option.frequency_high << 32) + ifpan.option.frequency_low;
                    //单频点数据复制到显示缓存 // 2022-11-22 12:05:57
                    if (show.ipan <= 40000000)
                    {// 2022-11-22 15:17:17 40Mhz (M:megahertz)                    
                        show.center_freq = frequency;
                        //检查数据包是否有错乱数据(120.0dbuv~-70.0dbuv)
                        short max = ifpan.data.Max();
                        short min = ifpan.data.Min();
                        if (max > 1000 || min < -500)
                        {
                            continue;
                        }
                        //避免漏频-频谱叠加处理
                        if (show.update)
                        {
                            show.update = false;
                            fft_temp.CopyTo(fft_wave, 0);
                            ifpan.data.CopyTo(fft_temp, 0);
                        }
                        else for (int i = 0; i < 1601; i++)
                            {
                                fft_temp[i] = (ifpan.data[i] > fft_temp[i]) ? ifpan.data[i] : fft_temp[i];
                            }
                        continue;
                    }
                }

                //频段扫描数据包解析 
                if (length == Marshal.SizeOf(pscan)) //3262
                {
                    //Console.WriteLine("频段扫描数据包:"+length);
                    //Console.WriteLine(length); // 2023-03-10 21:33
                    //统计接收到的数据包
                    show.pack_count++;
                    //频段扫描中心频率
                    show.center_freq = show.start_freq + show.ipan / 2;
                    //将收到的byte数据转换成结构体
                    pscan = (pscan_stream)BytesToStruct(data, typeof(pscan_stream));// 2022-11-24 17:09:43 pscan_strem
                    //得到开始频率
                    UInt64 start_freq = ((UInt64)pscan.option.StartFreq_high << 32) + pscan.option.StartFreq_low;
                    //得到结束频率
                    UInt64 stop_freq = ((UInt64)pscan.option.StopFreq_high << 32) + pscan.option.StopFreq_low;
                    //频率不在测量范围内
                    if (show.start_freq > start_freq || show.stop_freq < stop_freq)
                    {
                        continue;
                    }
                    //计算数据包偏移
                    int offset = (int)((start_freq - show.start_freq) / show.span); // 2022-12-10 21:52:00 第几个包
                    //检查数据包是否有错乱数据(120.0dbuv~-70.0dbuv)
                    short max = pscan.data.Max();
                    short min = pscan.data.Min();
                    if (max > 1000 || min < -500)
                    {
                        continue;
                    }

                }
            }
        }

        string tcpClient_Send(String cmd)
        {
            try
            {
                int index = 0;
                int size = 0;
                byte[] adujst = new Byte[1024 * 1024];

                //需要循环读取校准数据
                if (cmd == "save adjust\r")
                {
                    while (true)
                    {
                        byte[] Bytes = Encoding.ASCII.GetBytes("read adujst" + index + "\r");
                        index += 1;
                        tcpClient.Send(Bytes);
                        byte[] Rec = new byte[2048];
                        int len = tcpClient.Receive(Rec);
                        string p = Encoding.ASCII.GetString(Rec);
                        if (len == 2)
                        {
                            SaveFileDialog file = new SaveFileDialog();//定义新的文件保存位置控件
                            file.Filter = "校准数据(*.cal)|*.cal";//设置文件后缀的过滤
                            if (file.ShowDialog() == DialogResult.OK)//如果有文件保存路径
                            {
                                //StreamWriter sw = File.CreateText(file.FileName);

                                FileStream fs = new FileStream(file.FileName, FileMode.Create);//以追加的形式打开文件
                                fs.Write(adujst, 0, size);//写入byte[]型数据
                                fs.Flush();
                                fs.Close();
                            }
                            file.Dispose();
                            return "ok";
                        }
                        //读取的校准参数先放到缓存
                        for (int i = 0; i < len; i++)
                        {
                            adujst[size + i] = Rec[i];
                        }
                        //读取的校准参数数据总大小
                        size += len;
                    }
                }
                //常规命令，不需要特殊处理；只需要发送一次
                else
                {

                    byte[] Bytes = Encoding.ASCII.GetBytes(cmd);
                    tcpClient.Send(Bytes);
                    byte[] Rec = new byte[2048];
                    int len = tcpClient.Receive(Rec);
                    return Encoding.ASCII.GetString(Rec);
                }
            }
            catch
            {
                return "";
            }
        }

        private bool creat_socket(Int32 TCPPort, string ClientIP, Int32 RecPort)
        {
            try
            {
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse(ClientIP), TCPPort));

                IPAddress lep = IPAddress.Parse(((IPEndPoint)tcpClient.LocalEndPoint).Address.ToString());
                string lep_addr = lep.ToString();

                udpServes = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                udpServes.Bind(new IPEndPoint(IPAddress.Parse(lep_addr), RecPort));
                thrUDPRecv = new Thread(UDPReceiveMessage);
                thrUDPRecv.Start();

                //通知终端建立udp并发送数据 单频点扫描
                tcpClient_Send("TRAC:UDP:TAG:ON \"" + lep_addr + "\"," + RecPort.ToString() + ",FSCAN,MSCAN,IFPAN,PSCAN,CW,AUDIO\r");

                //频段扫描
                //tcpClient_Send("FREQ:SPAN " + show.span.ToString() + "\r");
                //tcpClient_Send("FREQ:PSCan:STARt " + show.start_freq.ToString() + "\r");
                //tcpClient_Send("STOP " + show.stop_freq.ToString() + "\r");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void conReceiverBtn_Click(object sender, EventArgs e)
        {
            if (creat_socket(Convert.ToInt32("5555"), switchIpText.Text, 4321))
            {
                //Console.WriteLine("接收机连接成功");
                //checkBox2.Checked = true;
                UInt64 freq = (UInt64)(Convert.ToDouble(centerReceivText.Text) * 1000000);
                tcpClient_Send("FREQ " + freq.ToString() + "\r");
                //tcpClient_Send("mfs_path " + comboBox6.SelectedIndex.ToString() + "\r");
            }
        }

        private void closeReceiverBtn_Click(object sender, EventArgs e)
        {
            tcpClient_Send("ABORT;\r\n*CLS;\r\n");
            //延时1秒
            Thread.Sleep(1);
            delect_socket();
        }

        private void singlePointBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1601; i++)
            {
                max_wave[i] = 350;
                
            }
            UInt64 freq = (UInt64)(Convert.ToDouble(centerReceivText.Text) * 1000000);
            Console.WriteLine("freq:" + freq);
            show.px = window_left_offset + 800;

            tcpClient_Send("FREQ " + freq.ToString() + "\r");
            show.start_freq = 0;
            show.stop_freq = 0;
            show.span = 40000000;//频段扫描每次上传的带宽数据
            show.ipan = 40000000; // 40 MHz //单频点、频段扫描分析带宽
            tcpClient_Send("FREQ:SPAN " + show.ipan.ToString() + "\r");
        }

        private void bandScanNumBtn_Click(object sender, EventArgs e)
        {

        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {

        }

        private void setFlowBtn_Click(object sender, EventArgs e)
        {

        }

        private void showDpxBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
