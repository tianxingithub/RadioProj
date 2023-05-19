using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace redioProj
{
    internal class LAD_0502
    {
        //#初始集合的大小
        const double CLEAN_SET_RATE = 0.1;
        //#理想的纯净抑制比，用来获取上阈值和下阈值参数,可以进行调整
        const double P_FA_DEC_CEIL = 0.01;
        const double P_FA_DEC_FLOOR = 0.1;
        //#传入的数据
        public List<int> data;
        //#传入数据可能含有负值，因此需要将整个频段往上移动
        public List<int> data_positive;
        //#传入数据长度
        public int length;
        //# 初始集合的大小
        public int clean_set_size;
        //#保存幅度值的平方
        public List<double> energy;
        //# 将Freq的数据按平方或绝对值排序保存在energy中，
        public List<double> energy_asc;
        //# ceil_threshold and floor threshold denote two thresholds
        public double ceil_threshold = 0;
        public double floor_threshold = 0;
        //# real_signal用来存储真实信号
        public List<List<int>> real_signal_index;
        //# 获取相邻信号间隔
        public List<int> adjacent_signal_interval;

        public LAD_0502(List<int> array)
        {
            data = array;
            //data_positive=data-data.Min()
            int min_ = data.Min();
            data_positive = data.Select(item => item - min_).ToList();
            length = data.Count;
            clean_set_size = 0;
            energy_asc = new List<double>();
            energy = new List<double>();
            adjacent_signal_interval = new List<int>();
            foreach (int i in data_positive)
            {
                double I = (double)(i * 1.0) / 10;
                //Console.WriteLine(I); //需要测试数据是否为double
                energy_asc.Add(Math.Pow(I, 2));
                energy.Add(Math.Pow(I, 2));
            }
            energy_asc.Sort();
        }

        //#设置初始集
        public void set_initial_set()
        {
            clean_set_size = (int)(length * CLEAN_SET_RATE);
            //可能还有添加

        }

        //#获取上阈值
        public double get_ceil_threshold(double P_FA_DEC = P_FA_DEC_CEIL)
        {
            //double T_CME = -Math.Log(P_FA_DEC, Math.E);
            //double init_set_mean = 0;
            //int init_set_size = clean_set_size;
            //for (int i = 0; i < init_set_size; i++)
            //{
            //    init_set_mean += energy_asc[i];
            //}
            //init_set_mean /= init_set_size;

            //while (energy_asc[init_set_size] < T_CME * init_set_mean)
            //{
            //    init_set_mean = (init_set_size * init_set_mean + energy_asc[init_set_size]) / (init_set_size + 1);
            //    init_set_size += 1;
            //    if (init_set_size == length)
            //        break;
            //}
            //ceil_threshold = T_CME * init_set_mean;
            double T_CME = -Math.Log(P_FA_DEC, Math.E);
            double clean_set_size = this.clean_set_size;
            double clean_set_mean = this.energy_asc.Take(this.clean_set_size).Average();
            while (this.energy_asc[(int)clean_set_size] < T_CME * clean_set_mean)
            {
                clean_set_mean = (clean_set_size * clean_set_mean + this.energy_asc[(int)clean_set_size]) / (clean_set_size + 1);
                clean_set_size += 1;
                if (clean_set_size == this.length)
                {
                    Console.WriteLine("not finding threshold");
                    break;
                }
            }
            this.ceil_threshold = T_CME * clean_set_mean;
            return this.ceil_threshold;
        }
        //#获取下阈值
        public double get_floor_threshold(double P_FA_DEC = P_FA_DEC_FLOOR)
        {
            //double T_CME = -Math.Log(P_FA_DEC);
            //double init_set_mean = 0;
            //int init_set_size = clean_set_size;
            //for (int i = 0; i < init_set_size; i++)
            //{
            //    init_set_mean += energy_asc[i];
            //}
            //init_set_mean /= init_set_size;
            //while (energy_asc[init_set_size] < T_CME * init_set_mean)
            //{
            //    init_set_mean = (init_set_size * init_set_mean + energy_asc[init_set_size]) / (init_set_size + 1);
            //    init_set_size += 1;
            //    if (init_set_size == length)
            //        break;
            //}
            //floor_threshold = T_CME * init_set_mean;
            double T_CME = -Math.Log(P_FA_DEC, Math.E);
            double clean_set_size = this.clean_set_size;
            double clean_set_mean = this.energy_asc.Take(this.clean_set_size).Average();
            while (this.energy_asc[(int)clean_set_size] < T_CME * clean_set_mean)
            {
                clean_set_mean = (clean_set_size * clean_set_mean + this.energy_asc[(int)clean_set_size]) / (clean_set_size + 1);
                clean_set_size += 1;
                if (clean_set_size == this.length)
                {
                    Console.WriteLine("not finding threshold");
                    break;
                }
            }
            this.floor_threshold = T_CME * clean_set_mean;
            return this.floor_threshold;
        }

        //#找到信号的索引
        public List<List<int>> find_signal_index()
        {
            List<List<int>> index_range_list = new List<List<int>>();
            int index = 1;

            while (index < length) //length正确
            {
                List<int> index_range = new List<int>();

                if (energy[index] >= floor_threshold) //floor_threshold is right
                {

                    index_range.Add(index - 1);
                    index_range.Add(index);
                    index += 1;

                    while (true)
                    {
                        if (index == length) break;
                        else
                        {
                            if (energy[index] >= floor_threshold)
                            {
                                index_range.Add(index);
                                index += 1;
                            }
                            else
                            {
                                index_range.Add(index);
                                index_range_list.Add(index_range);
                                index_range = new List<int>();
                                index += 1;
                                break;
                            }
                        }
                    }
                }
                index += 1;
            }

            List<List<int>> signal_index_range_list = new List<List<int>>();

            /*
            //来自ChartGPT
            foreach (List<int> item in index_range_list)
            {
                if (item.Max(index => energy[index]) >= ceil_threshold)
                {
                    signal_index_range_list.Add(item);
                }
            }
            */
            foreach (List<int> item in index_range_list)
            {
                double max_data_index = -1000;
                foreach (int i_ in item)
                {
                    max_data_index = max_data_index > energy[Math.Abs(i_)] ? max_data_index : energy[Math.Abs(i_)]; //索引过界
                }
                if (max_data_index >= ceil_threshold)
                {
                    signal_index_range_list.Add(item);
                }
            }

            real_signal_index = signal_index_range_list;

            return signal_index_range_list;
        }

        //返回对应的信号段
        //ChartGPT写了一个List<List<Object>>
        public List<List<List<int>>> get_pairs()//用pars数据之前要将数据缩小10倍
        {
            List<List<List<int>>> pairs = new List<List<List<int>>>();
            foreach (List<int> item in this.real_signal_index)
            {
                List<List<int>> pair = new List<List<int>>();
                List<int> pair_second = new List<int>();
                foreach (int index in item)
                {
                    pair_second.Add(data[index]); //用pair_second需要将其除以10
                }
                //if (pair_second.Max() > 0)
                //{
                pair.Add(item);
                pair.Add(pair_second);
                pairs.Add(pair);
                //}
            }
            return pairs;
        }

        //#找到相邻信号的间隔点数，即能确定相邻两个信号的频率相差范围
        /*来自ChartGPT
        public List<int> FindAdjacentInterval()
        {
            // 获取LDA得到的真实信号的相邻间隔
            for (int i = 0; i < this.signal_index_range_list.Count - 1; i++)
            {
                this.adjacent_signal_interval.Add(this.signal_index_range_list[i + 1][0] - this.signal_index_range_list[i][this.signal_index_range_list[i].Count - 1]);
            }
            return this.adjacent_signal_interval;
        }

        */
        List<int> find_adjacent_interval()
        {
            //real_signal_index = signal_index_range_list; 
            //for (int i = 0; i < signal_index_range_list.Count - 1; i++)
            for (int i = 0; i < real_signal_index.Count - 1; i++)
            {
                adjacent_signal_interval.Add(real_signal_index[i + 1][0] - real_signal_index[i].Last());
                //adjacent_signal_interval.Add(signal_index_range_list[i + 1][0] - signal_index_range_list[i].Last());
            }
            return adjacent_signal_interval;
        }

    }
}
