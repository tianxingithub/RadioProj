

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace LZClient.config {

    enum CmdType {
        TaskStar = 4001,    //4C检测任务开始（4001）
        JHDataSend = 4002,  //4C检测数据上传（4002）
        ImgNumSend = 4003,  //4C检测图片拍照数量信息（4003） 
        ImgDataSend = 4004, //4C检测图片上传（4004）
        TaskStop = 4005     //4C检测任务停止（4001）   
    }
    /// <summary>
    /// 系统全局参数
    /// </summary>
    public class SysParam {
        public static DataSet ds;

        private static string _cameraIP;
        public static string CameraIP {
            get { return _cameraIP; }
            set {
                _cameraIP = value;
                var dt = ds.Tables["CameraIP"];
                if (dt != null) {

                    dt.Rows[0][0] = _cameraIP;
                }
            }
        }

        private static int _cameraIRPort;
        public static int CameraIRPort {
            get { return _cameraIRPort; }
            set {
                _cameraIRPort = value;
                var dt = ds.Tables["CameraIRPort"];
                if (dt != null) {
                    dt.Rows[0][0] = _cameraIRPort;
                }
            }
        }

        private static int _cameraPicPort;
        public static int CameraPicPort {
            get { return _cameraPicPort; }
            set {
                _cameraPicPort = value;
                var dt = ds.Tables["CameraPort"];
                if (dt != null) {
                    dt.Rows[0][0] = _cameraPicPort;
                }
            }
        }


        //本机IP地址
        private static string _localIP;
        public static string LocalIP {
            get { return _localIP; }
            set {
                _localIP = value;
                var dt = ds.Tables["LocalIP"];
                if (dt != null) {

                    dt.Rows[0][0] = _localIP;
                }
            }
        }

        //本机IP地址
        private static int _locInfoUDPPort;
        public static int LocInfoUDPPort {
            get { return _locInfoUDPPort; }
            set {
                _locInfoUDPPort = value;
                var dt = ds.Tables["LocInfoUDPPort"];
                if (dt != null) {
                    dt.Rows[0][0] = _locInfoUDPPort;
                }
            }
        }
        private static int arcInfoUDPPort;
        public static int ARCInfoUDPPort {
            get { return arcInfoUDPPort; }
            set {
                arcInfoUDPPort = value;
                var dt = ds.Tables["ARCInfoUDPPort"];
                if (dt != null) {
                    dt.Rows[0][0] = arcInfoUDPPort;
                }
            }
        }

        //可见光帧率
        private static float _frameRateOfPIC;
        public static float FrameRateOfPIC {
            get { return _frameRateOfPIC; }
            set {
                _frameRateOfPIC = value;
                var dt = ds.Tables["FrameRateOfPIC"];
                if (dt != null) {
                    dt.Rows[0][0] = _frameRateOfPIC;
                }
            }
        }
        //红外光帧率
        private static float _frameRateOfIR;
        public static float FrameReteOfIR {
            get { return _frameRateOfIR; }
            set {
                _frameRateOfIR = value;
                var dt = ds.Tables["FrameReteOfIR"];
                if (dt != null) {
                    dt.Rows[0][0] = _frameRateOfIR;
                }
            }
        }

        #region  # Net Param
       
        #endregion

        #region # 图像大小
        private static int picW;
        public static int PicW {
            get { return picW; }
            set {
                picW = value;
                var dt = ds.Tables["PicSize"];
                if (dt != null) {
                    dt.Rows[0]["w"] = picW;
                }
            }
        }
        private static int picH;
        public static int PicH {
            get { return picH; }
            set {
                PicH = value;
                var dt = ds.Tables["PicSize"];
                if (dt != null) {
                    dt.Rows[0]["h"] = picH;
                }
            }
        }

        private static int irW;
        public static int IRW {
            get { return irW; }
            set {
                irW = value;
                var dt = ds.Tables["IRSize"];
                if (dt != null) {
                    dt.Rows[0]["w"] = irW;
                }
            }
        }
        private static int irH;
        public static int IRH {
            get { return irH; }
            set {
                irH = value;
                var dt = ds.Tables["IRSize"];
                if (dt != null) {
                    dt.Rows[0]["h"] = irH;
                }
            }
        }



        private static float _imgSizePic;
        public static float ImgSizePic {
            get { return _imgSizePic; }
            set {
                _imgSizePic = value;
                var dt = ds.Tables["ImgSizePic"];
                if (dt != null) {
                    dt.Rows[0][0] = _imgSizePic;
                }
            }
        }
        private static float _imgSizeIR;
        public static float ImgSizeIR {
            get { return _imgSizeIR; }
            set {
                _imgSizeIR = value;
                var dt = ds.Tables["ImgSizeIR"];
                if (dt != null) {
                    dt.Rows[0][0] = _imgSizeIR;
                }
            }
        }
        #endregion
        private static int _videoMaxSize;
        public static int VideoMaxSize {
            get { return _videoMaxSize; }
            set {
                _videoMaxSize = value;
                var dt = ds.Tables["VideoMaxSize"];
                if (dt != null) {
                    dt.Rows[0][0] = _videoMaxSize;
                }
            }
        }

        private static string _videoPath;

        public static string VideoPath {
            get { return _videoPath; }
            set {
                _videoPath = value;
                var dt = ds.Tables["VideoPath"];
                if (dt != null) {
                    dt.Rows[0][0] = _videoPath;
                }
            }
        }
        private static string dataPath;

        public static string DataPath {
            get { return dataPath; }
            set {
                dataPath = value;
                var dt = ds.Tables["DataPath"];
                if (dt != null) {
                    dt.Rows[0][0] = dataPath;

                }
            }
        }
        private static string wavePath;
        public static string WavePath {
            get { return wavePath; }
            set {
                wavePath = value;
                var dt = ds.Tables["WavePath"];
                if (dt != null) {
                    dt.Rows[0][0] = wavePath;

                }
            }
        }
        private static string basePath;
        public static string BasePath {
            get { return basePath; }
            set {
                basePath = value;
                var dt = ds.Tables["BasePath"];
                if (dt != null) {
                    dt.Rows[0][0] = basePath;
                }
            }
        }
        private static string excelSavePath;
        public static string ExcelSavePath {
            get { return excelSavePath; }
            set {
                excelSavePath = value;
                var dt = ds.Tables["ExcelSavePath"];
                if (dt != null) {
                    dt.Rows[0][0] = excelSavePath;
                }
            }
        }
        

        private static int _maxTemperature;
        public static int MaxTemperature {
            get { return _maxTemperature; }
            set {
                _maxTemperature = value;
                var dt = ds.Tables["MaxTemperature"];
                if (dt != null) {
                    dt.Rows[0][0] = _maxTemperature;
                }
            }
        }

        private static double maxzig;
        public static double Maxzig {
            get { return maxzig; }
            set {
                maxzig = value;
                var dt = ds.Tables["DeductScore"];
                if (dt != null) {
                    dt.Rows[0]["fMax"] = maxzig;
                }
            }
        }

        private static double minzig;
        public static double Minzig {
            get { return minzig; }
            set {
                minzig = value;
                var dt = ds.Tables["DeductScore"];
                if (dt != null) {
                    dt.Rows[0]["fMin"] = minzig;
                }
            }
        }

        private static double maxhei;
        public static double Maxhei {
            get { return maxhei; }
            set {
                maxhei = value;
                var dt = ds.Tables["DeductScore"];
                if (dt != null) {
                    dt.Rows[1]["fMax"] = maxhei;
                }
            }
        }

        private static double minhei;
        public static double Minhei {
            get { return minhei; }
            set {
                minhei = value;
                var dt = ds.Tables["DeductScore"];
                if (dt != null) {
                    dt.Rows[1]["fMin"] = minhei;
                }
            }
        }
        #region CQI计算参数
        //拉出值施工允许误差(mm)
        private static int deltaS;
        public static int DeltaS {
            get { return deltaS; }
            set {
                deltaS = value;
                var dt = ds.Tables["DeltaS"];
                if (dt != null) {
                    dt.Rows[0][0] = deltaS;
                }
            }
        }
        //接触线高度施工允许误差(mm)
        private static int deltaH;
        public static int DeltaH {
            get { return deltaH; }
            set {
                deltaH = value;
                var dt = ds.Tables["DeltaH"];
                if (dt != null) {
                    dt.Rows[0][0] = deltaH;
                }
            }
        }
        // CQI 管理值-高铁
        private static int cQIMgrH;
        public static int CQIMgrH {
            get { return cQIMgrH; }
            set {
                cQIMgrH = value;
                var dt = ds.Tables["CQIMgrH"];
                if (dt != null) {
                    dt.Rows[0][0] = cQIMgrH;
                }
            }
        }
        // CQI 管理值-普速
        private static double cQIMgrN;
        public static double CQIMgrN {
            get { return cQIMgrN; }
            set {
                cQIMgrN = value;
                var dt = ds.Tables["CQIMgrN"];
                if (dt != null) {
                    dt.Rows[0][0] = cQIMgrH;
                }
            }
        }

        #endregion
        //设备状态刷新频率(毫秒)
        public static int RefreshRateDevState { get; set; }

        

        static SysParam() {

        }
        public static void LoadConfig() {
            ds = XmlToDataSet("config\\config.xml");
            AnayzeConfig(ds);

        }
        public static DataSet XmlToDataSet(string xmlFilePath)
        {

            StreamReader sr = null;
            DataSet ds = new DataSet();
            try
            {
                sr = new StreamReader(xmlFilePath, System.Text.Encoding.UTF8);
                ds.ReadXml(sr);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sr.Close();
                //释放资源  

            }

            return ds;
        }
        public static void AnayzeConfig(DataSet ds) {
            try {
                #region  UDP 接收定位信息
                //本地IP
                var dt = ds.Tables["LocalIP"];
                if (dt != null) {
                    _localIP = dt.Rows[0][0].ToString();
                }



                //UDP 端口
                dt = ds.Tables["LocInfoUDPPort"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0][0].ToString(), out _locInfoUDPPort);
                }

                #endregion

                //相机IP
                dt = ds.Tables["CameraIP"];
                if (dt != null) {
                    _cameraIP = dt.Rows[0][0].ToString();
                }


                //端口
                dt = ds.Tables["CameraPicPort"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0][0].ToString(), out _cameraPicPort);
                }
                dt = ds.Tables["CameraIRPort"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0][0].ToString(), out _cameraIRPort);
                }
                dt = ds.Tables["ARCInfoUDPPort"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0][0].ToString(), out arcInfoUDPPort);
                }

                //帧率
                dt = ds.Tables["FrameRateOfPIC"];
                if (dt != null) {
                    float.TryParse(dt.Rows[0][0].ToString(), out _frameRateOfPIC);
                }
                dt = ds.Tables["FrameReteOfIR"];
                if (dt != null) {
                    float.TryParse(dt.Rows[0][0].ToString(), out _frameRateOfIR);
                }


                //图像大小
                dt = ds.Tables["ImgSizePic"];
                if (dt != null) {
                    float.TryParse(dt.Rows[0][0].ToString(), out _imgSizePic);
                }
                dt = ds.Tables["ImgSizeIR"];
                if (dt != null) {
                    float.TryParse(dt.Rows[0][0].ToString(), out _imgSizeIR);
                }

                dt = ds.Tables["PicSize"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0]["w"].ToString(), out picW);
                    int.TryParse(dt.Rows[0]["h"].ToString(), out picH);
                }
                dt = ds.Tables["IRSize"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0]["w"].ToString(), out irW);
                    int.TryParse(dt.Rows[0]["h"].ToString(), out irH);
                }
                //视频大小
                dt = ds.Tables["VideoMaxSize"];
                if (dt != null) {
                    int.TryParse(dt.Rows[0][0].ToString(), out _videoMaxSize);
                }

                dt = ds.Tables["DeductScore"];
                if (dt != null) {
                    maxzig =Convert.ToDouble( dt.Rows[0]["fMax"]);
                    minzig = Convert.ToDouble(dt.Rows[0]["fMin"]);
                    maxhei = Convert.ToDouble(dt.Rows[1]["fMax"]);
                    minhei = Convert.ToDouble(dt.Rows[1]["fMin"]);
                }
               



                dt = ds.Tables["VideoPath"];
                if (dt != null) {
                    _videoPath = dt.Rows[0][0].ToString();
                }
                
                dt = ds.Tables["DataPath"];
                if (dt != null) {
                    DataPath = dt.Rows[0][0].ToString();
                }
                dt = ds.Tables["WavePath"];
                if (dt != null) {
                    WavePath = dt.Rows[0][0].ToString();
                }
                dt = ds.Tables["BasePath"];
                if (dt != null) {
                    BasePath = dt.Rows[0][0].ToString();
                }

                dt = ds.Tables["ExcelSavePath"];
                if (dt != null) {
                    ExcelSavePath = dt.Rows[0][0].ToString();
                }
                #region # CQI计算参数
                dt = ds.Tables["DeltaS"];
                if (dt != null) {
                    deltaS = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                dt = ds.Tables["DeltaH"];
                if (dt != null) {
                    deltaH = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                dt = ds.Tables["CQIMgrH"];
                if (dt != null) {
                    cQIMgrH = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                dt = ds.Tables["CQIMgrN"];
                if (dt != null) {
                    cQIMgrN = Convert.ToInt32(dt.Rows[0][0].ToString());
                }

                #endregion

            } catch {
            }
        }

        /// <summary>
        /// 存储XML
        /// </summary>
        public static void Save() {
            DataSetToXml(ds, "config\\config.xml");
        }
        public static void DataSetToXml(DataSet ds, string saveXMLPath)
        {
            //如果文件DataTable.xml存在则直接删除
            if (File.Exists(saveXMLPath))
            {
                File.Delete(saveXMLPath);
            }
            ds.WriteXml(saveXMLPath);
        }
    }
}
