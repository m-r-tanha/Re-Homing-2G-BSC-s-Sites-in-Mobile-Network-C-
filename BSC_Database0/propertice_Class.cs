using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BSC_Database0
{
    class propertice_Class
    {
        private int i = 0;
        public string CELL, BSIC="", BCCH="", LAC="", CI="", CGI="", BSPWR="", NUMREQBP_CH0="", NUMREQBP_CH1="",HOP="",HSN="", SDCCH_CH0="", SDCCH_CH1="", GSM="", RXOTG="", GSM_bound="",NUMREQEGPRSBPC_CH0="",NUMREQEGPRSBPC_CH1="", NUMREQBP="";
        public string RSITE="", CONFACT="", TG="", HSN_CH0="", HSN_CH1="",HOP_CH0="",HOP_CH1="", MAIO_CH0="",MAIO_CH1="";
        //public string CELL_neyber;
        public string[] CELLR = new string[40] ;
        public string DCHNO="";

        public void propertic(string gn,string gn0,string bsc,string bound)
        {

            //----------------------- TG b176 ----------------- ----
            if (File.Exists(@"d:\DataBase_BSC\B176E_rxtcp.txt") && (bsc == "b176e"))
                {
                string[] line_rxtcp = File.ReadAllLines(@"d:\DataBase_BSC\B176E_rxtcp.txt");
                for (i = 0; i < line_rxtcp.Length; i++)
                {
                    if((line_rxtcp[i]!="")&& (line_rxtcp[i].StartsWith("RXOTG")))
                    {
                        string[] tg_rxtcp = line_rxtcp[i].Split(' ');
                    for (int j = 0; j < tg_rxtcp.Length; j++)
                    {
                        string gn1 = "";
                        if (bound == "900")
                        {
                             gn1 = gn0 + "A";
                        }
                        else
                        {
                            gn1 = gn0 + "D";
                        }
                        if (tg_rxtcp[j].StartsWith(gn1.ToUpper()))
                        {
                            string[] RXOTG_1 = tg_rxtcp[0].Split('-');
                            TG = RXOTG_1[1];
                            RXOTG= tg_rxtcp[0];
                        }
                    }
                    }
                }
            }
           //----------------------- RSITE B176e----------------- ----
            if (File.Exists(@"d:\DataBase_BSC\B176E_rxmop.txt")&&bsc=="b176e")
            {
                string[] line_rxmop = File.ReadAllLines(@"d:\DataBase_BSC\B176E_rxmop.txt");
                for (i = 0; i < line_rxmop.Length; i++)
                {
                     string[] tg_rxmop = line_rxmop[i].Split(' ');
                    if ((string.Compare(tg_rxmop[0],RXOTG)==0))
                    {
                        for(int x=0;x<tg_rxmop.Length;x++)
                            if(tg_rxmop[x].StartsWith("GN"))
                        RSITE = tg_rxmop[x];
                        string[] confact0 = line_rxmop[i + 6].Split(' ');
                        CONFACT = confact0[24];
                    }
                }
            }

            //----------------------- TG b177 ---------------------
            if (File.Exists(@"d:\DataBase_BSC\B177E_rxtcp.txt") && (bsc == "b177e"))
            {
                string[] line_rxtcp = File.ReadAllLines(@"d:\DataBase_BSC\B177E_rxtcp.txt");
                for (i = 0; i < line_rxtcp.Length; i++)
                {

                    if ((line_rxtcp[i] != "") && (line_rxtcp[i].StartsWith("RXOTG")))
                    {
                        string[] tg_rxtcp = line_rxtcp[i].Split(' ');
                        for (int j = 0; j < tg_rxtcp.Length; j++)
                        {
                            string gn1 = "";
                            if (bound == "900")
                            {
                                gn1 = gn0 + "A";
                            }
                            else
                            {
                                gn1 = gn0 + "D";
                            }
                            if (tg_rxtcp[j].StartsWith(gn1.ToUpper()))
                            {
                                string[] RXOTG_1 = tg_rxtcp[0].Split('-');
                                TG = RXOTG_1[1];
                                RXOTG = tg_rxtcp[0];
                            }
                        }
                    }
                }
            }
            //----------------------- RSITE B177e----------------- ----
            if (File.Exists(@"d:\DataBase_BSC\B177E_rxmop.txt") && bsc == "b177e")
            {
                string[] line_rxmop = File.ReadAllLines(@"d:\DataBase_BSC\B177E_rxmop.txt");
                for (i = 0; i < line_rxmop.Length; i++)
                {
                    string[] tg_rxmop = line_rxmop[i].Split(' ');
                    if ((string.Compare(tg_rxmop[0], RXOTG) == 0))
                    {
                       

                        for (int x = 0; x < tg_rxmop.Length; x++)
                            if (tg_rxmop[x].StartsWith("GN"))
                                RSITE = tg_rxmop[x];
                        string[] confact0 = line_rxmop[i + 6].Split(' ');
                        CONFACT = confact0[24];
                    }
                }
            }
            //----------------------- TG B178e ----------------- ----
            if (File.Exists(@"d:\DataBase_BSC\B178E_rxtcp.txt") && (bsc == "b178e"))
            {
                string[] line_rxtcp = File.ReadAllLines(@"d:\DataBase_BSC\B178E_rxtcp.txt");
                for (i = 0; i < line_rxtcp.Length; i++)
                {

                    if ((line_rxtcp[i] != "") && (line_rxtcp[i].StartsWith("RXOTG")))
                    {
                        string[] tg_rxtcp = line_rxtcp[i].Split(' ');
                        for (int j = 0; j < tg_rxtcp.Length; j++)
                        {
                            string gn1 = "";
                            if (bound == "900")
                            {
                                gn1 = gn0 + "A";
                            }
                            else
                            {
                                gn1 = gn0 + "D";
                            }
                            if (tg_rxtcp[j].StartsWith(gn1.ToUpper()))
                            {
                                string[] RXOTG_1 = tg_rxtcp[0].Split('-');
                                TG = RXOTG_1[1];
                                RXOTG = tg_rxtcp[0];
                            }
                        }
                    }
                }
            }
            else 
               TG="there is no tg";
                
            //----------------------- RSITE b178e----------------- ----
            if (File.Exists(@"d:\DataBase_BSC\B178E_rxmop.txt") && bsc == "b178e")
            {
                string[] line_rxmop = File.ReadAllLines(@"d:\DataBase_BSC\B178E_rxmop.txt");
                for (i = 0; i < line_rxmop.Length; i++)
                {
                    string[] tg_rxmop = line_rxmop[i].Split(' ');
                    if ((string.Compare(tg_rxmop[0], RXOTG) == 0))
                    {
                        
                        for (int x = 0; x < tg_rxmop.Length; x++)
                            if (tg_rxmop[x].StartsWith("GN"))
                                RSITE = tg_rxmop[x];
                        string[] confact0 = line_rxmop[i + 6].Split(' ');
                        CONFACT = confact0[24];
                    }
                }
            }
       //-------------------- GSM --------------
            if (gn.EndsWith("D") || gn.EndsWith("E") || gn.EndsWith("F"))
                GSM_bound = "GSM1800";
            else GSM_bound = "GSM900";

            
            //----------------------- BSIC  CGI  CELL BCCH GSM ----
            if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
            {
                string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                for (i = 0; i < line_rldep.Length; i++)
                {
                    if (line_rldep[i].StartsWith(gn))
                    {
                        string[] gn_rldep = line_rldep[i].Split(' ');
                        string[] gn_rldep1 = line_rldep[i + 3].Split(' ');
                        if (gn_rldep.Length > 12)
                        {
                            CELL = gn_rldep[0];
                            string[] cgi = gn_rldep[2].Split('-');
                            GSM = gn_rldep1[41];
                            LAC = cgi[2];
                            CI = cgi[3];
                            BSIC = gn_rldep[6];
                            //BCCH = gn_rldep[12];
                            if (gn_rldep.Length > 12)
                            {
                                if (gn_rldep[12] != "") BCCH = gn_rldep[12];
                                else BCCH = gn_rldep[11];
                            }
                            else BCCH = gn_rldep[11];
                            CGI = gn_rldep[2];
                        }
                    }
                    //----------------
                    if ((line_rldep[i].StartsWith(gn)&&gn.StartsWith("MA"))||(line_rldep[i].StartsWith(gn)&&gn.StartsWith("SM")))
                    {
                        string[] gn_rldep = line_rldep[i].Split(' ');
                             BSIC = gn_rldep[6];
                             BCCH = gn_rldep[11];
                             CGI = gn_rldep[2];
                             CELL = gn_rldep[0];
                            if (line_rldep[i].StartsWith("INT") || line_rldep[i].StartsWith("EXT"))
                            {
                                string[] gn_rldep1 = line_rldep[i].Split(' ');
                                GSM = gn_rldep1[49];
                            }
                    }
                    //------------------
                }
            }
            //---------------------  DCHNO  ----
            if (File.Exists(@"d:\DataBase_BSC\rlcfp.txt"))
            
            {
                DCHNO = "";
                int y = 0;
               
                //int c=0;
                char[] dch = new char[7] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                string[] line_rlcfp = File.ReadAllLines(@"d:\DataBase_BSC\rlcfp.txt");
                
                int end = line_rlcfp.Length;
                for (i = 0; i <line_rlcfp.Length; i++)
                {
                    if (line_rlcfp[i].StartsWith(gn))
                    {
                       string[] frq=new string[32];
                       int temp = 0;
                       int[] int_fre=new int[15];

                        do
                        {
                            if (line_rlcfp[i].Length > 0 && (!line_rlcfp[i].StartsWith("CELL")) & (!line_rlcfp[i].StartsWith("CHGR")) & (!line_rlcfp[i].StartsWith("GN")))
                            {
                                // y++;
                                
                                string[] rlcfp = line_rlcfp[i].Split(' ');
                                int lengh = rlcfp.Length;
                               // frq[c]=rlcfp[lengh-1];
                                if(rlcfp[lengh-1]!="")
                                  temp=int.Parse(rlcfp[lengh-1]);
                               
                                if ((temp >= 64 && temp <= 124) || (temp >= 587 && temp <= 661))
                                    if (temp != int.Parse(BCCH))
                                    {
                                        frq[y++] = temp.ToString();
                                    }
                                /*if (y == 1)
                                  
                                    DCHNO = "";
                                else
                                {
                                    if (DCHNO == "")
                                        DCHNO = rlcfp[lengh - 1];
                                    else
                                        DCHNO = rlcfp[lengh - 1] + "&" + DCHNO;
                                }*/
                            }
                            
                            i++;
                        } while (!line_rlcfp[i + 1].StartsWith("GN"));
                       
                        if (y == 1)
                            DCHNO = frq[0];
                        if (y == 2)
                            DCHNO = frq[0] + "&" + frq[1] ;
                        if (y == 3)
                            DCHNO = frq[0] + "&" + frq[1] + "&" + frq[2];

                }
                }
                
            }
            //-------------------- BSPWR ------------------
            if (File.Exists(@"d:\DataBase_BSC\rlcpp.txt"))
            {
                string[] line_rlcpp = File.ReadAllLines(@"d:\DataBase_BSC\rlcpp.txt");
                for (i = 0; i < line_rlcpp.Length; i++)
                {
                    if (line_rlcpp[i].StartsWith(gn))
                    {
                        string[] rlcpp = line_rlcpp[i].Split(' ');
                        BSPWR = rlcpp[5];
                    }
                }

            }

            //-------------------- SDCCH ------------------
            if (File.Exists(@"d:\DataBase_BSC\rlcfp.txt"))
            {
                
                string[] line_rlcfp = File.ReadAllLines(@"d:\DataBase_BSC\rlcfp.txt");
                for (i = 0; i < line_rlcfp.Length; i++)
                {
                    if (line_rlcfp[i].StartsWith(gn))
                    {
                        do{
                            i++;
                            if (line_rlcfp[i].StartsWith(" 0"))
                            {
                                string[] t1 = line_rlcfp[i].Split(' ');
                                SDCCH_CH0 = t1[17];
                            }
                            if (line_rlcfp[i].StartsWith(" 1"))
                            {
                                string[] t2 = line_rlcfp[i].Split(' ');
                                SDCCH_CH1 = t2[17];
                            }


                         } while (!line_rlcfp[i + 1].StartsWith("GN"));
                    }
                }

            }
            //--------------------- NUMREQBP ------------------
            if (File.Exists(@"d:\DataBase_BSC\rlbdp.txt"))
            {
                NUMREQBP_CH0 = "";
                NUMREQBP_CH1 = "";
                string[] line_rlbdp = File.ReadAllLines(@"d:\DataBase_BSC\rlbdp.txt");
                for (i = 0; i < line_rlbdp.Length-1; i++)
                {
                    if (line_rlbdp[i].StartsWith(gn))
                    {
                        do{
                            i++;
                            if (line_rlbdp[i].StartsWith(" 0"))
                            {
                                string[] t1 = line_rlbdp[i].Split(' ');
                                NUMREQBP_CH0 = t1[8];
                                NUMREQEGPRSBPC_CH0=t1[18];
                            }
                            if (line_rlbdp[i].StartsWith(" 1"))
                            {
                                string[] t2 = line_rlbdp[i].Split(' ');
                                if(t2[6]!="")
                                {
                                    NUMREQBP_CH1 = t2[6];
                                    NUMREQEGPRSBPC_CH1=t2[16];
                                }
                                    if (t2[7] != "")
                                    {
                                    NUMREQBP_CH1 = t2[7];
                                   NUMREQEGPRSBPC_CH1=t2[17];
                                    }
                                    if (t2[8] != "")
                                    {
                                        NUMREQBP_CH1 = t2[8];
                                        NUMREQEGPRSBPC_CH1 = t2[18];
                                    }
                            }
                        
                         } while (!line_rlbdp[i + 1].StartsWith("GN"));
                    }
                }
                }
            //-------------------------- HSN   HOP -------------
            if (File.Exists(@"d:\DataBase_BSC\rlchp.txt"))
            {
                HSN_CH0 = "";
                HSN_CH1="";
                HOP_CH0="";
                HOP_CH1="";
                MAIO_CH0 = "";
                MAIO_CH1 = "";
                string[] line_rlchp = File.ReadAllLines(@"d:\DataBase_BSC\rlchp.txt");
                
                for (i = 0; i < line_rlchp.Length; i++)
                {
                    if (line_rlchp[i].StartsWith(gn))
                    do{
                        i++;
                        if (line_rlchp[i].StartsWith(" 0"))
                        {
                            string[] rlchp = line_rlchp[i].Split(' ');
                            if (rlchp[5] != "") HSN_CH0 = rlchp[5];
                            if (rlchp[6] != "") HSN_CH0 = rlchp[6];

                            if (rlchp[8] != "") HOP_CH0 = rlchp[8];
                            if (rlchp[9] != "") HOP_CH0 = rlchp[9];

                            if (rlchp[10] != "") MAIO_CH0 = rlchp[10];
                            if (rlchp[11] != "") MAIO_CH0 = rlchp[11];
                            if (rlchp[13] != "") MAIO_CH0 = rlchp[13];
                            if (MAIO_CH0 == "0") MAIO_CH0 = "0&1&2";
                        }

                        if (line_rlchp[i].StartsWith(" 1"))
                        {
                            string[] rlchp = line_rlchp[i].Split(' ');
                            if (rlchp[5] != "") HSN_CH1 = rlchp[5];
                            if (rlchp[6] != "") HSN_CH1 = rlchp[6];

                            if (rlchp[8] != "") HOP_CH1 = rlchp[8];
                            if (rlchp[9] != "") HOP_CH1 = rlchp[9];

                            if (rlchp[11] != "") MAIO_CH1 = rlchp[11];
                            if (rlchp[12] != "") MAIO_CH1 = rlchp[12];
                            if (rlchp[13] != "") MAIO_CH1 = rlchp[13];

                            if (MAIO_CH1 == "0") MAIO_CH1 = "0&1&2";
                        }
                    } while (!line_rlchp[i].StartsWith("GN"));
                }
            }
            //----------------------------------------------------------
             //-----------------------  rlnrp ---------------------------
            if (File.Exists(@"d:\DataBase_BSC\rlnrp.txt"))
            {
                string[] line_rlnrp = File.ReadAllLines(@"d:\DataBase_BSC\rlnrp.txt");
               
                for (i = 0; i < line_rlnrp.Length-2; i++)
                {
                    if ((string.Compare("CELL", line_rlnrp[i], true) == 0)&&(string.Compare(gn, line_rlnrp[i+1], true) == 0))
                    {
                        int b=1;
                        i++;
                        do
                        {
                              i = i + 1; 
                           
                            if ((line_rlnrp[i].StartsWith("GN") || line_rlnrp[i].StartsWith("MA") || line_rlnrp[i].StartsWith("SM")))
                            {
                                string[] rlnrp = line_rlnrp[i].Split(' ');
                                CELLR[b] = rlnrp[0];
                                b++;
                            }
                        } while (string.Compare(line_rlnrp[i], "CELL") != 0);
                    }

                }
            }
        }
    }
}

