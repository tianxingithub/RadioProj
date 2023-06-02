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
using DevComponents.DotNetBar.Controls;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Newtonsoft.Json;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing.Drawing2D;

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

            // tianxin  初始化信息
            //初始化默认值
            show.px = window_left_offset + 800;
            show.py = window_top_offset + 160;
            all_signal = new List<SignalInfo>();

            // 初始化业务信息
            business = new Business[]
            {
                new Business /*1*/ { fre = new double [2]{20,74.6}, description = "移动，空间研究，射电，广播，无线电定位"},
                new Business /*2*/ { fre = new double [2]{74.6,87}, description = "航空无线电导航"},
                new Business /*3*/ { fre = new double [2]{87,108}, description = "广播，无线电定位，移动"},
                new Business /*4*/ { fre = new double [2]{108,117.9}, description = "航空无线电导航"},
                new Business /*5*/ { fre = new double [2]{117.9,137}, description = "航空移动"},
                new Business /*6*/ { fre = new double [2]{137,156.5}, description = "卫星移动，无线电定位，空间研究，空间操作，移动"},
                new Business /*7*/ { fre = new double [2]{156.5,167}, description = "水上移动，陆地移动，卫星移动，移动，空间操作"},
                new Business /*8*/ { fre = new double [2]{167,223}, description = "广播，移动，无线电定位，空间研究"},
                new Business /*9*/ { fre = new double [2]{223,399.9}, description = "移动，航空无线电导航，无线电定位，空间操作，射电天文"},
                new Business /*10*/ { fre = new double [2]{399.9,450}, description = "移动，卫星移动，无线电导航，气象辅助，空间研究，空间操作，无线电定位，业余"},
                new Business /*11*/ { fre = new double [2]{450,470}, description = "移动，航空无线电导航，无线电定位"},
                new Business /*12*/ { fre = new double [2]{470,806}, description = "广播，移动，航空无线电导航，无线电定位"},
                new Business /*13*/ { fre = new double [2]{806,960}, description = "移动，无线电定位"},
                new Business /*14*/ { fre = new double [2]{960,1164}, description = "航空无线电导航，卫星无线电导航"},
                new Business /*15*/ { fre = new double [2]{1164,1215}, description = "航空无线电导航，卫星无线电导航"},
                new Business /*16*/ { fre = new double [2]{1215, 1300}, description = "无线电定位，空间研究，移动，业余，卫星无线电导航，空间研究"},
                new Business /*17*/ { fre = new double [2]{1300,1452}, description = "无线电定位，航空无线电盗号，卫星无线电导航，移动"},
                new Business /*18*/ { fre = new double [2]{1452,1492}, description = "移动，广播，卫星广播，无线电定位"},
                new Business /*19*/ { fre = new double [2]{1492,1535}, description = "移动，无线电定位，卫星移动，空间操作，卫星地球探测"},
                new Business /*20*/ { fre = new double [2]{1535,1626.5}, description = "卫星无限导航，卫星无线测定，卫星移动，航空无线电导航"},
                new Business /*21*/ { fre = new double [2]{1626.5,1710}, description = "卫星移动，射电天文，空间研究，气象辅助，移动，卫星气象"},
                new Business /*22*/ { fre = new double [2]{1710,1950}, description = "移动"},
                new Business /*23*/ { fre = new double [2]{1950,1980}, description = "移动"},
                new Business /*24*/ { fre = new double [2]{1980,2025}, description = "移动，卫星移动"},
                new Business /*25*/ { fre = new double [2]{2025,2110}, description = "空间操作，卫星地球探测，移动"},
                new Business /*26*/ { fre = new double [2]{2110,2170}, description = "移动，空间研究"},
                new Business /*27*/ { fre = new double [2]{2170,2200}, description = "卫星移动"},
                new Business /*28*/ { fre = new double [2]{2200,2290}, description = "空间操作，卫星地球探测，空间研究，移动"},
                new Business /*29*/ { fre = new double [2]{2290,2300}, description = "空间研究，移动"},
                new Business /*30*/ { fre = new double [2]{2300,2450}, description = "移动，无线电定位，业余"},
                new Business /*31*/ { fre = new double [2]{2450,2500}, description = "移动，无线电定位，卫星移动，卫星无线电测定"},
                new Business /*32*/ { fre = new double [2]{2500,2635}, description = "移动，卫星移动，无线电定位，卫星无线电测定，卫星广播"},
                new Business /*33*/ { fre = new double [2]{2635,2680}, description = "移动，卫星广播，射电天文，空间研究"},
                new Business /*34*/ { fre = new double [2]{2680,2700}, description = "空间研究，射电天文，卫星地球探测，移动"},
                new Business /*35*/ { fre = new double [2]{2700,2900}, description = "无线电定位，航空无线电导航"},
                new Business /*36*/ { fre = new double [2]{2900, 3100}, description = "无线电导航，无线电定位"},
                new Business /*37*/ { fre = new double [2]{3100, 3400}, description = "无线电定位，卫星地球探测，空间研究"},
                new Business /*38*/ { fre = new double [2]{3400, 3700}, description = "卫星，业余，移动"},
                //# new Business /*37*/ { fre = new double [2]{3100,3300}, description = "无线电定位，卫星地球探测，空间研究"},
                //# new Business /*38*/ { fre = new double [2]{3400, 3700}, description = "卫星，业余，移动"},
                new Business /*39*/ { fre = new double [2]{3700, 4200}, description = "卫星，移动"},
                new Business /*40*/ { fre = new double [2]{4200, 4400}, description = "航空无线电导航"},
                new Business /*41*/ { fre = new double [2]{4400, 4500}, description = "移动"},
                new Business /*42*/ { fre = new double [2]{4500, 4800}, description = "卫星，移动"},
                new Business /*43*/ { fre = new double [2]{4800, 4990}, description = "移动，射电天文"},
                new Business /*44*/ { fre = new double [2]{4990, 5150}, description = "航空移动，卫星航空移动，航空无线电"},
                new Business /*45*/ { fre = new double [2]{5150, 5250}, description = "卫星，航空无线电导航，移动"},
                new Business /*46*/ { fre = new double [2]{5250, 5350}, description = "卫星地球探测，无线电定位，移动"},
                new Business /*47*/ { fre = new double [2]{5350, 5470}, description = "卫星地球探测，无线电定位，空间研究，无线电导航"},
                new Business /*48*/ { fre = new double [2]{5470, 5650}, description = "水上无线电导航，无线电定位，移动，空间移研究"},
                new Business /*49*/ { fre = new double [2]{5650, 5850}, description = "无线电定位，无线电定位，业余，空间研究"},
                new Business /*50*/ { fre = new double [2]{5850, 5925}, description = "卫星，移动，无线电定位"},
                new Business /*51*/ { fre = new double [2]{5925, 6020}, description = "卫星，移动"}
            };

            // 初始化业务对应的阈值
            ceil_floor = new CeilFloor[]
            {
                new CeilFloor /*1*/ {floor = 0.005, ceil = 0.002},
                new CeilFloor /*2*/ {floor =  0.021, ceil = 0.011},
                new CeilFloor /*3*/ {floor = 0.005, ceil = 0.002},
                new CeilFloor /*4*/ {floor = 0.005, ceil =  0.002},
                new CeilFloor /*5*/ {floor = 0.0201, ceil = 0.0118},
                new CeilFloor /*6*/ {floor = 0.0201, ceil = 0.0118},
                new CeilFloor /*7*/ {floor = 0.0401, ceil = 0.0333},
                new CeilFloor /*8*/ {floor = 0.03, ceil = 0.02},//#含宽带信号时处理存在问题
                new CeilFloor /*9*/ {floor = 0.0051, ceil = 0.0011},
                new CeilFloor /*10*/ {floor = 0.0005, ceil = 0.0001},
                new CeilFloor /*11*/ {floor = 0.0005, ceil = 0.0001},
                new CeilFloor /*12*/ {floor = 0.0005, ceil = 0.0001},
                new CeilFloor /*13*/ {floor = 0.0005, ceil = 0.0001},
                new CeilFloor /*14*/ {floor = 0.0011, ceil = 0.0006},
                new CeilFloor /*15*/ {floor = 0.0041, ceil = 0.0021},
                new CeilFloor /*16*/ {floor = 0.0501, ceil = 0.0201},
                new CeilFloor /*17*/ {floor = 0.0501, ceil = 0.0201},
                new CeilFloor /*18*/ {floor = 0.0501, ceil = 0.0201},
                new CeilFloor /*19*/ {floor = 0.0501, ceil = 0.0301},
                new CeilFloor /*20*/ {floor = 0.0501, ceil = 0.0301},
                new CeilFloor /*21*/ {floor = 0.0501, ceil = 0.0250},
                new CeilFloor /*22*/ {floor = 0.0501, ceil = 0.0201},//#含有带宽信号
                new CeilFloor /*23*/ {floor = 0.0501, ceil = 0.0201 },//#宽带信号需要特殊处理
                new CeilFloor /*24*/ {floor = 0.04, ceil = 0.01},
                new CeilFloor /*25*/ {floor = 0.04, ceil = 0.02},
                new CeilFloor /*26*/ {floor = 0.04, ceil = 0.01},//#宽带信号，需特殊处理
                new CeilFloor /*27*/ {floor = 0.04, ceil = 0.01},
                new CeilFloor /*28*/ {floor = 0.04, ceil = 0.01},
                new CeilFloor /*29*/ {floor = 0.05, ceil = 0.02},
                new CeilFloor /*30*/ {floor = 0.4, ceil = 0.1},//#含有带宽信号
                new CeilFloor /*31*/ {floor = 0.01, ceil = 0.005},//#含有带宽信号
                new CeilFloor /*32*/ {floor = 0.02, ceil = 0.01},//#含宽带信号，需特殊处理
                new CeilFloor /*33*/ {floor = 0.05, ceil = 0.02},//#不好处理，有问题
                new CeilFloor /*34*/ {floor = 0.0501, ceil = 0.0201},
                new CeilFloor /*35*/ {floor = 0.05, ceil = 0.0201},
                new CeilFloor /*36*/ {floor = 0.05, ceil = 0.02},
                new CeilFloor /*37*/ {floor =  0.05, ceil = 0.02},
                new CeilFloor /*38*/ {floor = 0.03, ceil = 0.01},
                new CeilFloor /*39*/ {floor = 0.1, ceil = 0.03},  //# 含有宽带信号，不好处理
                new CeilFloor /*40*/ {floor = 0.1, ceil = 0.025},
                new CeilFloor /*41*/ {floor = 0.1, ceil = 0.025},
                new CeilFloor /*42*/ {floor = 0.1, ceil = 0.025},
                new CeilFloor /*43*/ {floor = 0.005, ceil = 0.002},
                new CeilFloor /*44*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*45*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*46*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*47*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*48*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*49*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*50*/ {floor = 0.1, ceil = 0.02},
                new CeilFloor /*51*/ {floor = 0.1, ceil = 0.02},
                //# new CeilFloor /*38*/ {floor = 0.07, ceil =  0.03},
                //# new CeilFloor /*39*/ {floor = 0.2001, ceil = 0.0160},//#含有宽带信号，不好处理
                //# new CeilFloor /*40*/ {floor = 0.0501, ceil = 0.0403},
                //# new CeilFloor /*41*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*42*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*43*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*44*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*45*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*46*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*47*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*48*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*49*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*50*/ {floor = 0.2, ceil = 0.16},
                //# new CeilFloor /*51*/ {floor = 0.2, ceil = 0.15},
                //# new CeilFloor /*52*/ {floor = 0.3, ceil = 0.2},
                //# new CeilFloor /*53*/ {floor = 0.3, ceil = 0.21},
            };

            //系统数值初始化
            show.center_freq = 100000000;
            show.ipan = 40000000;
            show.start_freq = 20000000;// 
            show.stop_freq = 420000000;// 420Mhz
            show.span = 40000000;// 40Mhz
            //用于绘制荧光频谱
            point_bmp = new Bitmap(dpxBox.Width, dpxBox.Height);
            dpxBox.Visible = false;

            //初始化播放器
            try
            {
                pcm.waveOut = new WaveOut();
                WaveFormat wf = new WaveFormat(32000, 2);
                pcm.bufferedWaveProvider = new BufferedWaveProvider(wf);
                pcm.waveOut.Init(pcm.bufferedWaveProvider);
                pcm.waveOut.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭主窗口，保存最新的配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tcpClient_Send("ABORT;\r\n*CLS;\r\n");
            //setAllSignalFalse();
            //延时1秒
            Thread.Sleep(1);
            //关闭定时器
            timer_fft.Enabled = false;

            //断开连接
            delect_socket();
            SysParam.Save();
        }

        // tianxin 加全局变量

        static int dpx_time = 0; // 荧光频谱的次数

        //全频段信号数据
        List<SignalInfo> all_signal;

        Business[] business;
        CeilFloor[] ceil_floor;
        DataTable dataTable;//Redis数据显示表

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


        // 荧光频谱
        Boolean draw_point = false;
        Bitmap point_bmp;
        int[,] points = new int[1600, 700];
        // 荧光频谱偏移量
        int up = 100;
        int[] maxArr;
        JsonData m;

        // 结构体
        public class Business
        {
            public double[] fre { get; set; }
            public string description { get; set; }
        }
        public struct CeilFloor
        {
            public double ceil { get; set; }
            public double floor { get; set; }

        }
        public struct SignalInfo
        {
            public short left { get; set; }
            public double center { get; set; }
            public short right { get; set; }
        }

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
        // 在下面添加函数

        void draw_color_box(Graphics gp, int max_red, int up)   // 绘制渐变色矩形
        {

            int priod = max_red / 4;
            Rectangle rect = new Rectangle(1200, 20, 400, 20);
            LinearGradientBrush br = new LinearGradientBrush(rect, Color.Black, Color.Black, LinearGradientMode.Horizontal);
            ColorBlend cb = new ColorBlend(); // [0,1]
            cb.Positions = new[] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
            cb.Colors = new[] { Color.DarkBlue, Color.CornflowerBlue, Color.DarkGreen, Color.Chartreuse, Color.Yellow, Color.Orange, Color.Red };
            br.InterpolationColors = cb;
            // 标识
            gp.FillRectangle(br, rect);
            gp.DrawString("0%", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1200, 45);
            gp.DrawString("10%", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1200 + 100 * 4, 45);

            // y坐标
            gp.DrawLine(new Pen(Brushes.White), 35, 0, 35, 700);
            gp.DrawString("-50", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up + 50 - 5);
            gp.DrawString("-75", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up + 75 - 5);
            gp.DrawString("0", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up - 5);
            gp.DrawString("100", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up - 100 - 5);
            gp.DrawString("200", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up - 200 - 5);
            gp.DrawString("400", new Font("宋体", 12), new SolidBrush(Color.White), 5, 700 - up - 400 - 5);

            // x坐标
            gp.DrawLine(new Pen(Brushes.White), 35, 700, 35 + 1600, 700);
            double l_center_freq = (double)show.center_freq / 1000000.0 - show.ipan / 2000000.0;
            double m_center_freq = (double)show.center_freq / 1000000.0;
            double h_center_freq = (double)show.center_freq / 1000000.0 + show.ipan / 2000000.0;
            //gp.DrawString(, new Font("宋体", 12), new SolidBrush(Color.White), 35 - 5, 700);
            gp.DrawString(l_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), 35, 700);
            gp.DrawString(m_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), 40 + 800 - 30, 700);
            gp.DrawString(h_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), 40 + 1600 - 50, 700);
        }

        Pen choosePen(Graphics gp, int i, int max_red) // 选择绘制荧光频谱点的画笔
        {

            Color sourceColor;// = Color.Blue;
            Color destColor;// = Color.Red;
            int redSpace;// = destColor.R - sourceColor.R;
            int greenSpace;// = destColor.G - sourceColor.G;
            int blueSpace;//= destColor.B - sourceColor.B;

            Color vColor = new Color();

            double percet = (i * 1.0) / dpx_time; // 点出现的比例
            //Console.WriteLine(i + "," + dpx_time + "," + percet);

            //max_red = (int)(percet * 1000);
            max_red = 200;
            int pix_priod = max_red / 6;

            int index = (int)(percet * 8000); // 点的占比0-100
            i = index;
            switch (i / pix_priod)
            {
                case 0:
                    sourceColor = Color.DarkBlue;
                    destColor = Color.CornflowerBlue;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                case 1:
                    sourceColor = Color.CornflowerBlue;
                    destColor = Color.DarkGreen;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                case 2:
                    sourceColor = Color.DarkGreen;
                    destColor = Color.Chartreuse;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                case 3:
                    sourceColor = Color.Chartreuse;
                    destColor = Color.Yellow;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                case 4:
                    sourceColor = Color.Yellow;
                    destColor = Color.Orange;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                case 5:
                    sourceColor = Color.Orange;
                    destColor = Color.Red;
                    redSpace = destColor.R - sourceColor.R;
                    greenSpace = destColor.G - sourceColor.G;
                    blueSpace = destColor.B - sourceColor.B;

                    vColor = Color.FromArgb(
                        sourceColor.R + (int)((double)(i % pix_priod + 1) / pix_priod * redSpace),
                        sourceColor.G + (int)((double)(i % pix_priod + 1) / pix_priod * greenSpace),
                        sourceColor.B + (int)((double)(i % pix_priod + 1) / pix_priod * blueSpace)
                    );
                    break;
                default:
                    vColor = Color.Red;
                    break;
            }


            return new Pen(vColor);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1)//鼠标单击
                {
                    show.px = e.Location.X;
                    show.py = e.Location.Y;
                }
                if (e.Clicks == 2)//鼠标双击跳到相应单频点测量
                {
                    double l_center_freq = (double)show.center_freq / 1000000.0 - show.ipan / 2000000.0;
                    double p_center_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (show.px - window_left_offset);
                    centerReceivText.Text = p_center_freq.ToString();
                    centerText.Text = p_center_freq.ToString();
                    UInt64 freq = (UInt64)(Convert.ToDouble(centerReceivText.Text) * 1000000);
                    tcpClient_Send("FREQ " + freq.ToString() + "\r");
                    show.center_freq = (ulong)(freq);
                    //show.px = window_left_offset + 800;   
                    singlePointBtn_Click(singlePointBtn, null);
                }
            }
        }

        private double draw_box(Graphics g, int width, int height, int x1, int y1)// 绘制频谱显示的框架
        {
            //背景颜色
            g.FillRectangle(Brushes.CornflowerBlue, 0, 0, signalImgBox.Width, signalImgBox.Height);

            //上下两条横线
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1, x1 + width, y1);
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1 + height, x1 + width, y1 + height);

            //左右两条竖线
            g.DrawLine(new Pen(Brushes.White, 1), x1, y1, x1, y1 + height);
            g.DrawLine(new Pen(Brushes.White, 1), x1 + width, y1, x1 + width, y1 + height);

            Pen fix_line = new Pen(Brushes.White, 1);
            Pen flg_line = new Pen(Brushes.Orange, 1);
            fix_line.DashPattern = new float[] { 2, 4 };
            flg_line.DashPattern = new float[] { 2, 4 };

            //横向虚线
            int wy = height / 10;
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine((i == 8) ? flg_line : fix_line, x1, y1 + i * wy, x1 + width, y1 + i * wy);
            }

            //竖向虚线
            int wx = width / 20;
            for (int i = 0; i < 20; i++)
            {
                g.DrawLine((i == 10) ? flg_line : fix_line, x1 + i * wx, y1, x1 + i * wx, y1 + height);
            }

            //竖向数标【120~-30dbuv】

            for (int i = 0; i < 11; i++)
            {
                int x_val = 120 - (i * wy) / 2;
                g.DrawString(x_val.ToString(), new Font("宋体", 12), new SolidBrush(Color.White), 5, y1 + i * wy - 10);
            }

            //横向数标【频率】
            double l_center_freq = (double)show.center_freq / 1000000.0 - show.ipan / 2000000.0;
            double m_center_freq = (double)show.center_freq / 1000000.0;
            double h_center_freq = (double)show.center_freq / 1000000.0 + show.ipan / 2000000.0;
            g.DrawString(l_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), x1, y1 + height + 5);
            g.DrawString(m_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), x1 + width / 2 - 20, y1 + height + 5);
            g.DrawString(h_center_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.White), x1 + width - 70, y1 + height + 5);

            return l_center_freq;
        }

        private void timer1_Tick(object sender, EventArgs e) // tianxin:我认为是主体部分，这里是25ms调用一次进行刷新
        {
            // 绘制荧光频谱
            if (draw_point)
            {

                //int max_red = 20;
                int max_red = 100;
                //int up = (Convert.ToInt32(textBox4.Text));
                //fft_wava[0,1600]是数据
                Graphics gp = Graphics.FromImage(point_bmp);
                draw_color_box(gp, max_red, up);
                for (int i = 0; i < 1600; i++)
                {
                    int y = fft_wave[i];
                    y += up;
                    if (y < 0 || y >= (700))
                        continue;
                    points[i, y]++;
                    //根据points[i, y]选择颜色
                    Pen cp = choosePen(gp, points[i, y], max_red);
                    gp.DrawEllipse(cp, new Rectangle(i + 37, 700 - y + 37, 1, 1));
                }
                //显示绘制的bmp图片
                dpxBox.CreateGraphics().DrawImage(point_bmp, 0, 0);
                //释放避免内存溢出
                gp.Dispose();
            }


            Bitmap bmp = new Bitmap(signalImgBox.Width, signalImgBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            // 导入代码块
            int val3_py = 0;
            int val3_px = window_left_offset; // window_left[top]_offset:频谱坐标偏移 line48
            int val3_buf = 0;

            int max_py = 5000;
            int max_px = window_left_offset;
            double l_center_freq = draw_box(g, 1600, 300, window_left_offset, window_top_offset);

            //将缓存数据压缩并绘制在画图板上
            for (int i = 0; i < 1601; i++)
            {
                int divx = (int)(show.ipan / show.span);
                divx = (divx > 0) ? divx : 1;
                int val1 = -400;
                int val2 = -400;
                int val3 = 0;
                //如果显示带宽大于show.span那么压缩数据
                //针对频段扫描
                for (int j = 0; j < divx; j++)
                {
                    val1 = fft_wave[i * divx + j];
                    val2 = (val1 > val2) ? val1 : val2;
                    val3 = (Int16)(300 - (val2 / 5));
                }

                if (i > 0)
                {
                    //绘制实时频谱线条
                    g.DrawLine(new Pen(Brushes.GreenYellow, 1), window_left_offset + i, val3_buf, window_left_offset + i + 1, val3);
                    //绘制最大值频谱线
                    g.DrawLine(new Pen(Brushes.Red, 1), window_left_offset + i, max_wave[i - 1], window_left_offset + i + 1, max_wave[i]);
                }

                //保存最大值
                if (maxFreKeepCheck.Checked == false)
                {
                    max_wave[i] = 360;
                }
                else if (val3 < max_wave[i])
                {
                    max_wave[i] = val3;
                }

                //保存当前点数据以便下一个点画线
                val3_buf = val3;

                //写数据到瀑布图缓存
                //pbg_wave[i] = (Int16)val2;

                //找出频谱实时值中的最大值及点位
                if (max_py > val3)
                {
                    max_px = window_left_offset + i;
                    max_py = val3;
                    show.max_dbuv = (float)val2 / 10;
                    show.max_index = (UInt64)i;
                }

                //将鼠标点击对应的值记录下来
                if (window_left_offset + i == show.px)
                {
                    val3_py = val3;
                    val3_px = show.px;
                    show.cursor_dbuv = (float)val2 / 10;
                }
            }

            //所有信号的绘制[只绘制40MHz内的] 【静态加载的部分】
            if (all_signal.Count != 0)
            {
                int cen = (int)show.center_freq / 1000000;//signalList.FindIndex(x => x.center == signalList.Max(y => y.center));
                int startIndex = all_signal.FindIndex(x_ => x_.center >= (cen - 20));
                int endIndex = all_signal.FindLastIndex(x_ => x_.center <= (cen + 20));
                List<SignalInfo> rangeList = all_signal.GetRange(startIndex, endIndex - startIndex + 1);

                // 绘制范围内的所有信号
                foreach (var sig in rangeList)
                {
                    double x = (sig.center - cen + 20) * 40;
                    int max_fre = (int)x;
                    // 绘制信息附近信号
                    int left = max_fre - 2;
                    int right = max_fre + 2;
                    if (widthSignCheck.Checked) // 信号标记方式
                    {
                        left = max_fre - sig.left;
                        right = max_fre + sig.right;
                    }
                    for (int i = left; i <= right; i++)
                    {
                        i = (i <= 0) ? 1 : i;
                        float yy1 = (float)fft_wave[i - 1];
                        float yy2 = (float)fft_wave[i];
                        g.DrawLine(new Pen(Brushes.Red, 1), window_left_offset + i, 300 - (yy1 / 5), window_left_offset + i + 1, 300 - (yy2 / 5));

                    }
                    //g.DrawString(sig.center.ToString("#0.0"), new Font("宋体", 8), new SolidBrush(Color.Red), //数组越界
                    //    max_fre + window_left_offset - 20, (float)(300 - ((int)fft_wave[max_fre] / 5)) - 20);

                    //g.DrawString(sig.center.ToString("▼"), new Font("宋体", 8), new SolidBrush(Color.Yellow),
                    //    max_fre + window_left_offset - 20, (float)(300 - ((int)fft_wave[max_fre] / 5)) - 30);
                    //Console.WriteLine(max_fre + "- - - -- - - - -- ");
                }
                g.DrawString("该范围内信号个数：" + rangeList.Count.ToString(), new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 40, 20);
            }



            //频谱最大值
            show.max_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (max_px - window_left_offset);
            if (focusFreCheck.Checked == true)
            { //显示鼠标点的横坐符号
                g.DrawString("▼", new Font("宋体", 12), new SolidBrush(Color.Red), val3_px - 9, val3_py - 16);
                g.DrawString(show.cursor_freq.ToString() + "MHz", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), val3_px - 17, val3_py - 30);
            }
            //显示鼠标点对应的文字
            g.DrawString("dbuv：" + show.cursor_dbuv.ToString() + "dbuv", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1300, 10);
            show.cursor_freq = l_center_freq + (((double)show.ipan / 1000000.0) / 1600) * (show.px - window_left_offset);
            g.DrawString("freq：" + show.cursor_freq.ToString() + "Mhz", new Font("宋体", 12), new SolidBrush(Color.GreenYellow), 1300, 30);


            //显示绘制的bmp图片
            signalImgBox.CreateGraphics().DrawImage(bmp, 0, 0);
            //pictureBox1.Dispose();
            //释放避免内存溢出
            g.Dispose();
            bmp.Dispose();
            show.update = true;
        }


        void get_signal(int[] max, int busy_index) // 根据业务求信号
        {
            // 需要将busy_index-1，数组从0开始标记
            Business busy = business[busy_index - 1]; // double[] fre, string description
            CeilFloor cf = ceil_floor[busy_index - 1];// double ceil, double floor
            Console.WriteLine("- - - - - - - - - - - - - - -- - -  {" + busy.fre[0] + "," + busy.fre[1] + "} 【" + busy.description + "】 - - - - - - - - - - - - - - -- - -  ");
            int start = (int)(busy.fre[0] * 40) - 800;
            int end = (int)(busy.fre[1] * 40) - 800;
            Console.WriteLine("start:" + start + ",end:" + end);
            List<int> arr_max = new List<int>();
            for (int i = start; i < end; i++) arr_max.Add(max[i]);

            LAD_0502 lad = new LAD_0502(arr_max);
            lad.set_initial_set();
            lad.get_ceil_threshold(cf.ceil + 0.0001);
            lad.get_floor_threshold(cf.floor + 0.0001);

            lad.find_signal_index();
            if (lad.ceil_threshold > lad.floor_threshold && cf.floor > cf.ceil)
            {
                Console.WriteLine("上阈值的纯净抑制比" + cf.ceil);
                Console.WriteLine("下阈值的纯净抑制比" + cf.floor);
                Console.WriteLine("获得的上阈值" + lad.ceil_threshold);
                Console.WriteLine("获得的下阈值" + lad.floor_threshold);
                var paris = lad.get_pairs();
                //
                foreach (var pair in paris)
                {
                    int pd = pair[1].IndexOf(pair[1].Max());
                    int lrpd = pd;
                    pd = pair[0][pd];
                    double cen = busy.fre[0] + (double)pd * 1.0 / 40;
                    //Console.WriteLine("中心频率：" + center);
                    all_signal.Add(new SignalInfo { center = cen, left = (short)(lrpd - 1), right = (short)(pair[0].Count - lrpd) });
                    //带宽 pair[0].Count，中心频率 cen
                    string sCen = cen.ToString("#0.0");
                    //save_singal(sCen, pair[0].Count);

                }
                Console.WriteLine(paris.Count);
            }


        }

        private void delect_socket()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                //tcpClient.Dispose();
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
        public static object BytesToStruct(byte[] bytes, Type strcutType) // 解析数据包
        {
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


        private void UDPReceiveMessage(object obj) // 获取接收机的数据
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
                    length = udpServes.Receive(data);// 卡在这里可能是防火墙的问题
                    //if (length == 3270)// 2022-11-24 22:01:36 
                    //    ps++;
                    //if (length == 12868)
                    //{
                    //    Console.WriteLine(ps);
                    //    Console.WriteLine(Marshal.SizeOf(audio));
                    //    ps = 0;
                    //}
                    //Console.WriteLine("udp数据包:" + length);//length:3270|12868 
                }
                catch
                {
                    continue;
                }
                //if (draw_point == false) // 如果在显示荧光频谱则不要声音
                //{
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
                //}

                //单频点数据包解析 
                if (length == Marshal.SizeOf(ifpan))
                {
                    //统计接收到的数据包
                    show.pack_count++;
                    //将收到的byte数据转换成结构体
                    ifpan = (ifpan_stream)BytesToStruct(data, typeof(ifpan_stream));
                    //得到中心频率
                    UInt64 frequency = ((UInt64)ifpan.option.frequency_high << 32) + ifpan.option.frequency_low;
                    //单频点数据复制到显示缓存 
                    if (show.ipan <= 40000000)
                    {
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
                    //Console.WriteLine("- - -- - - - 频段扫描数据");
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
                    //拷贝数据包
                    pscan.data.CopyTo(fft_wave, offset * 1601);
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
                    //Console.WriteLine("- - -- - - -- - - "+cmd);
                    byte[] Bytes = Encoding.ASCII.GetBytes(cmd);
                    tcpClient.Send(Bytes);
                    byte[] Rec = new byte[2048];
                    int len = tcpClient.Receive(Rec);
                    //Console.WriteLine("- - -- - - -- - - " + len);
                    return Encoding.ASCII.GetString(Rec);
                }
            }
            catch
            {
                return "";
            }
        }

        private bool creat_socket(Int32 TCPPort, string ClientIP, Int32 RecPort) // 创建套接字
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

        // ----------------------------------------------------下面函数均为界面按钮的响应事件

        private void conReceiverBtn_Click(object sender, EventArgs e)
        {
            //var t1 = creat_socket(Convert.ToInt32(textBoxX1.Text), switchIpText.Text, 4321);
            //Console.WriteLine("- - -- - - -- - - "+t1);
            if (creat_socket(Convert.ToInt32(textBoxX1.Text), switchIpText.Text, 4321))
            {
                //string s1 = switchIpText.Text;
                //Console.WriteLine(textBoxX1.Text + "       " + switchIpText.Text+ "           "+ centerReceivText.Text);
                UInt64 freq = (UInt64)(Convert.ToDouble(centerReceivText.Text) * 1000000);
                tcpClient_Send("FREQ " + freq.ToString() + "\r");
                //Console.WriteLine("- - -- - - -- - - ");
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
            //Console.WriteLine("freq:" + freq);
            show.px = window_left_offset + 800;

            tcpClient_Send("FREQ " + freq.ToString() + "\r");
            show.start_freq = 0;
            show.stop_freq = 0;
            show.span = 40000000;//频段扫描每次上传的带宽数据
            show.ipan = 40000000; // 40 MHz //单频点、频段扫描分析带宽
            tcpClient_Send("FREQ:SPAN " + show.ipan.ToString() + "\r");

            //刷新荧光频谱
            if (this.widthSignCheck.Text == "结束荧光频谱")
            {
                this.dpxBox.Visible = false;
                this.signalImgBox.Visible = true;
                this.signalViewBox.Visible = true;

                this.dpxBox.Visible = true;
                this.signalImgBox.Visible = false;
                this.signalViewBox.Visible = false;

                point_bmp = new Bitmap(dpxBox.Width, dpxBox.Height);
                points = new int[1600, 700];
                dpx_time = 0;

            }
        }

        private void bandScanNumBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1601; i++)
            {
                max_wave[i] = 350;
            }
            UInt64 strart_freq = (UInt64)(Convert.ToDouble(startFreqText.Text) * 1000000);
            UInt64 stop_freq = (UInt64)(Convert.ToDouble(stopFreqText.Text) * 1000000);
            UInt64 span_freq = 40000000;

            if (spanFreqBox.SelectedIndex == 0) span_freq = 40000000;
            if (spanFreqBox.SelectedIndex == 1) span_freq = 20000000;
            if (spanFreqBox.SelectedIndex == 2) span_freq = 10000000;


            //UInt64 span_freq = (UInt64)((comboBox2.SelectedIndex == 0) ? 40000000 : 20000000);
            UInt64 mod_freq = (stop_freq - strart_freq) % span_freq;
            //扫描带宽判断
            if (strart_freq > stop_freq - span_freq)
            {
                MessageBox.Show("开始频率不能小于结束频率,请用单频点测量功能！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //修改设置的停止频率
            if (mod_freq > 0)
            {
                stopFreqText.Text = ((stop_freq + (span_freq - mod_freq)) / 1000000).ToString();
                stop_freq = (UInt64)(Convert.ToDouble(stopFreqText.Text) * 1000000);
            }

            show.start_freq = strart_freq;
            show.stop_freq = stop_freq;
            show.span = span_freq;
            show.ipan = (show.stop_freq - show.start_freq);

            tcpClient_Send("FREQ:SPAN " + show.span.ToString() + "\r");
            tcpClient_Send("FREQ:PSCan:STARt " + show.start_freq.ToString() + "\r");
            tcpClient_Send("STOP " + show.stop_freq.ToString() + "\r");

        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            maxArr = Enumerable.Repeat(-1000, 240000).ToArray();
            try
            {
                for (int index = 2; index <= 11; index++)
                {
                    string file = "E:/DataBase/2023-05-08/室内_2023-05-08_21-14-55/第" + index.ToString() + "个数据.json";
                    string jsonData = File.ReadAllText(file);
                    m = JsonConvert.DeserializeObject<JsonData>(jsonData);
                    for (int i = 0; i < m.freData.Count; i++) maxArr[i] = maxArr[i] < m.freData[i] ? m.freData[i] : maxArr[i];
                    double freq = Convert.ToDouble(centerText.Text);
                    int span = ((int)freq - 40) * 40;
                    for (int i = 0; i < 1600; i++) fft_wave[i] = (short)m.freData[i + span];
                    for (int i = 1; i <= 51; i++)
                        get_signal(maxArr, i);
                }
            }
            catch
            {
                MessageBox.Show("检查文件路径和文件个数是否正确", "加载Json文件出错");

            }

        }

        private void setFlowBtn_Click(object sender, EventArgs e)
        {
            up = Convert.ToInt32(flowText.Text);
            this.dpxBox.Visible = false;
            this.signalImgBox.Visible = true;
            this.signalViewBox.Visible = true;

            this.dpxBox.Visible = true;
            this.signalImgBox.Visible = false;
            this.signalViewBox.Visible = false;

            point_bmp = new Bitmap(dpxBox.Width, dpxBox.Height);
            points = new int[1600, 700];
            dpx_time = 0;
        }

        private void showDpxBtn_Click(object sender, EventArgs e)
        {
            if (this.showDpxBtn.Text == "显示荧光频谱")
            {
                this.dpxBox.Visible = true;
                this.signalImgBox.Visible = false;
                this.signalViewBox.Visible = false;
                this.showDpxBtn.Text = "结束荧光频谱";
                draw_point = true;

            }

            else if (this.showDpxBtn.Text == "结束荧光频谱")
            {
                this.dpxBox.Visible = false;
                this.signalImgBox.Visible = true;
                this.signalViewBox.Visible = true;
                this.showDpxBtn.Text = "显示荧光频谱";
                flowText.Text = "0";
                draw_point = false;
                points = new int[1600, 700];
                point_bmp = new Bitmap(dpxBox.Width, dpxBox.Height);
                dpx_time = 0;


            }
        }

        private void aheadFre40_Click(object sender, EventArgs e)
        {
            double freq = Convert.ToDouble(centerText.Text);
            int span = ((int)freq - 40) * 40;
            freq -= 40;
            if (freq < 40) freq = 6000;
            centerText.Text = (freq).ToString();
            centerReceivText.Text = (freq).ToString();

            show.center_freq = (ulong)(freq * 1000000);


            if (m != null)
                for (int i = 0; i < 1600; i++) fft_wave[i] = (short)m.freData[i + span];

        }

        private void nextFre40_Click(object sender, EventArgs e)
        {
            double freq = Convert.ToDouble(centerText.Text);
            freq += 40;
            if (freq > 6000) freq = 40;
            centerText.Text = (freq).ToString();
            centerReceivText.Text = (freq).ToString();
            show.center_freq = (ulong)(freq * 1000000);
            int span = ((int)freq - 40) * 40;

            if (m != null)
                for (int i = 0; i < 1600; i++) fft_wave[i] = (short)m.freData[i + span];


        }

        private void setCenterFreBtn_Click(object sender, EventArgs e)
        {
            double freq = Convert.ToDouble(centerText.Text);

            show.center_freq = (ulong)(freq * 1000000);
            int span = ((int)freq - 40) * 40;

            if (m != null)
                for (int i = 0; i < 1600; i++) fft_wave[i] = (short)m.freData[i + span];
        }

        
    }
}
