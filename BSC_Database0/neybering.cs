using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace BSC_Database0
{
    class neybering
    {
        public string cell_bsc="";
        public void neyber(string cel)
        {
            cell_bsc = "";
            if (cel.StartsWith("MA"))
                cell_bsc = "Mazandaran";
            if (cel.StartsWith("SM"))
                cell_bsc = "Semnan";
            if (cel.StartsWith("NK"))
                cell_bsc = "Khorasan Shomali";
            if (cell_bsc == "")
            {
                if (File.Exists(@"D:\DataBase_BSC\bsc border\b178e.txt"))
                {
                    string[] line_cellp = File.ReadAllLines(@"D:\DataBase_BSC\bsc border\b178e.txt");
                    for (int i = 0; i < line_cellp.Length; i++)
                    {
                        string[] gn_p = line_cellp[i].Split('\t');
                        for (int j = 0; j < gn_p.Length; j++)
                        {
                            if ((string.Compare(gn_p[j], cel, true) == 0))
                            {
                                cell_bsc = "b178e";
                            }
                        }
                    }
                }
                if (File.Exists(@"D:\DataBase_BSC\bsc border\b177e.txt"))
                {
                    string[] line_cellp = File.ReadAllLines(@"D:\DataBase_BSC\bsc border\b177e.txt");
                    for (int i = 0; i < line_cellp.Length; i++)
                    {
                        string[] gn_p = line_cellp[i].Split('\t');
                        for (int j = 0; j < gn_p.Length; j++)
                        {
                            if ((string.Compare(gn_p[j], cel, true) == 0))
                            {
                                cell_bsc = "b177e";
                            }
                        }
                    }
                }

                if (File.Exists(@"D:\DataBase_BSC\bsc border\b176e.txt"))
                {
                    string[] line_cellp = File.ReadAllLines(@"D:\DataBase_BSC\bsc border\b176e.txt");
                    for (int i = 0; i < line_cellp.Length; i++)
                    {
                        string[] gn_p = line_cellp[i].Split('\t');
                        for (int j = 0; j < gn_p.Length; j++)
                        {
                            if ((string.Compare(gn_p[j], cel, true) == 0))
                            {
                                cell_bsc = "b176e";
                            }
                        }
                    }
                }
                if (File.Exists(@"D:\DataBase_BSC\bsc border\b179e.txt"))
                {
                    string[] line_cellp = File.ReadAllLines(@"D:\DataBase_BSC\bsc border\b179e.txt");
                    for (int i = 0; i < line_cellp.Length; i++)
                    {
                        string[] gn_p = line_cellp[i].Split('\t');
                        for (int j = 0; j < gn_p.Length; j++)
                        {
                            if ((string.Compare(gn_p[j], cel, true) == 0))
                            {
                                cell_bsc = "b179e";
                            }
                        }
                    }
                }
                if (File.Exists(@"D:\DataBase_BSC\bsc border\b180e.txt"))
                {
                    string[] line_cellp = File.ReadAllLines(@"D:\DataBase_BSC\bsc border\b180e.txt");
                    for (int i = 0; i < line_cellp.Length; i++)
                    {
                        string[] gn_p = line_cellp[i].Split('\t');
                        for (int j = 0; j < gn_p.Length; j++)
                        {
                            if ((string.Compare(gn_p[j], cel, true) == 0))
                            {
                                cell_bsc = "b180e";
                            }
                        }
                    }
                }
            }
        }
    }
}
