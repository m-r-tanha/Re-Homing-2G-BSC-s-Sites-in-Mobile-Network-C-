using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BSC_Database0
{
    public partial class Form1 : Form
    {
        propertice_Class detail = new propertice_Class();
        neybering hamsaeh = new neybering();
        public string sector1, sector2, sector3;
        public string sector4, sector5, sector6;
        public string bound;
        public string dchno;
        public string bcch, bsic;
        public int Number_of_TRX_A, Number_of_TRX_B, Number_of_TRX_C,Number_of_TRX_D, Number_of_TRX_E, Number_of_TRX_F;
        public Form1()
        {
            InitializeComponent();
            
            if(File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                if(File.Exists(@"d:\DataBase_BSC\rlmfp.txt"))
                    if(File.Exists(@"d:\DataBase_BSC\rlnrp.txt"))
                        if(File.Exists(@"d:\DataBase_BSC\rlchp.txt"))
                            if(File.Exists(@"d:\DataBase_BSC\rlcfp.txt"))
                                if(File.Exists(@"d:\DataBase_BSC\rlnrp.txt"))
                                    if(File.Exists(@"d:\DataBase_BSC\rlbdp.txt"))
                                        if(File.Exists(@"d:\DataBase_BSC\bsc border\b176e.txt"))
                                            if(File.Exists(@"d:\DataBase_BSC\bsc border\b177e.txt"))
                                                if(File.Exists(@"d:\DataBase_BSC\bsc border\b178e.txt"))
                                                    if(File.Exists(@"d:\DataBase_BSC\bsc border\b179e.txt"))
                                                        if (File.Exists(@"d:\DataBase_BSC\bsc border\b180e.txt"))
                                                        {
                                                            MessageBox.Show("قبل از اجرای برنامه حتما از صحت فایل ها (با رجوع به صفحه بارگذاری)مطلع شوید ");
                                                        }
                                                        else
                                                        { MessageBox.Show("فایلها ناقص می باشد لطفا فایل ها را بروز نمائید "); }


        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            bound = "900";
            string gn = textBox1.Text;
            string bsc = "";
            string gn0 = gn;
            gn = gn.ToUpper();

            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\900");
            Create_Folder(@"D:\DataBase_BSC\86\900");
            Create_Folder(@"D:\DataBase_BSC\94\900");
            Create_Folder(@"D:\DataBase_BSC\eliminate");

            StreamWriter sw = new StreamWriter("D:\\DataBase_BSC\\84\\900\\" + gn0 + "_84" + ".txt");
            if ((checkBox1.Checked == true))
            {
                sector1 = "A";
                gn = gn + sector1;
                detail.propertic(gn, gn0, bsc, bound);
                
                MessageBox.Show(detail.DCHNO);
               // if ((detail.CGI == "") || (detail.BSIC == "") || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")
                 //   MessageBox.Show("The Data System is Blank");
                sw.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE= GSM900;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ",AGBLK=1;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                sw.WriteLine("RLCFI:CELL=" + gn + ",CHGR=0,DCHNO=" + detail.DCHNO + ";");
                sw.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw.WriteLine("RLIMI:CELL=" + gn + ";");
                sw.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB=" + detail.BSPWR + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=33,BSPWRT=" + detail.BSPWR + ";");
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSPWR="+BSTXPWR+",BSRXMIN=102,BSRXSUFF=110;");
                sw.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",IHO=OFF,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                sw.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                sw.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88;");

                sw.WriteLine("RLPCC:CELL=" + gn + ",QDESUL=20;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",REGINTUL=5;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",LCOMPUL=50;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",QCOMPUL=60;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",DTXFUL=5;");

                sw.WriteLine("RLPCI:CELL=" + gn + ";");
                sw.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",SSLENUL=5;");

                sw.WriteLine("RLBCC:CELL=" + gn + ",SSDESDL=82;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SSLENDL=3;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",REGINTDL=1;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF;");

                //sw.WriteLine("RLBCC:CELL=" + gn + ",QLENDL=5;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QDESDL=20;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QCOMPDL=60;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",BSPWRMINP=30;");

                sw.WriteLine("RLBCI:CELL=" + gn + ";");
                sw.WriteLine("RLLHC:CELL=" + gn + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=OFF;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=0,NUMREQBPC=" + detail.NUMREQBP_CH0 + ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=1,NUMREQBPC=" + detail.NUMREQBP_CH1 + ";");
                }
                //if (detail.NUMREQBP =="") 
                  //  MessageBox.Show("  را در فایل 84 دستی وارد کنید  NUMREQBP نیست لطفا GPRS در این ورژن امکان ایحاد دستورات ");
                sw.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=33,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=20,NECI=1,MBCR=2;");
                sw.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" +detail.SDCCH_CH0 + ",CBCH=NO,TN=1&&7;");
                sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0+ ",HSN=" + detail.HSN_CH0 + ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH=" + detail.SDCCH_CH1 + ",CBCH=NO,TN=1&&7;");
                    sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP=" + detail.HOP_CH1 + ",HSN=" + detail.HSN_CH1 + ";");
                }
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");//chrate
                sw.WriteLine("RLSLI:CELL=" + gn + ";");
                sw.WriteLine("RLVLE:CHTYPE=TCH;");
                sw.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40,HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
            }

            //-----------------------------------------------------------------------------------
            if ((checkBox2.Checked == true))
            {
                sector2 = "B";
                gn = textBox1.Text;
                gn = gn.ToUpper();
                gn = gn + sector2;
                detail.propertic(gn, gn0, bsc, bound);
                MessageBox.Show(detail.DCHNO);
               // if (detail.CGI == "" || detail.BSIC == "" || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")

                sw.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE=GSM900;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ",AGBLK=1;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                sw.WriteLine("RLCFI:CELL=" + gn + ",CHGR=0,DCHNO=" + detail.DCHNO + ";");
                sw.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw.WriteLine("RLIMI:CELL=" + gn + ";");
                sw.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB=" + detail.BSPWR + ";");
                sw.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=33,BSPWRT=" + detail.BSPWR + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSPWR="+BSTXPWR+",BSRXMIN=102,BSRXSUFF=110;");
                sw.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",IHO=OFF,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                sw.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                sw.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",SSLENUL=5;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",QDESUL=20;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",REGINTUL=5;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",LCOMPUL=50;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",QCOMPUL=60;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",DTXFUL=5;");
                sw.WriteLine("RLPCI:CELL=" + gn + ";");
                sw.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");

                sw.WriteLine("RLBCC:CELL=" + gn + ",SSDESDL=82;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SSLENDL=3;");
               // sw.WriteLine("RLBCC:CELL=" + gn + ",REGINTDL=1;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF;");

                //sw.WriteLine("RLBCC:CELL=" + gn + ",QLENDL=5;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QDESDL=20;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QCOMPDL=60;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",BSPWRMINP=30;");


                sw.WriteLine("RLBCI:CELL=" + gn + ";");
                sw.WriteLine("RLLHC:CELL=" + gn + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=OFF;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=0,NUMREQBPC=" + detail.NUMREQBP_CH0+ ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=1,NUMREQBPC=" + detail.NUMREQBP_CH1 + ";");
                }
                //if (detail.NUMREQBP =="") MessageBox.Show("  را در فایل 84 دستی وارد کنید  NUMREQBP نیست لطفا GPRS در این ورژن امکان ایحاد دستورات ");
                sw.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=33,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=20,NECI=1,MBCR=2;");
                sw.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                
                sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" + detail.SDCCH_CH0 + ",CBCH=NO,TN=1&&7;");
                sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0+ ",HSN=" + detail.HSN_CH0 + ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH=" + detail.SDCCH_CH1 + ",CBCH=NO,TN=1&&7;");
                    sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP=" + detail.HOP_CH1 + ",HSN=" + detail.HSN_CH1   + ";");
                }
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");//chrate
                sw.WriteLine("RLSLI:CELL=" + gn + ";");
                sw.WriteLine("RLVLE:CHTYPE=TCH;");
                sw.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40,HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
            }
            //----------------------------------------------- Sector C  -----------------------------------
            if ((checkBox3.Checked == true))
            {
                sector3 = "C";
                gn = textBox1.Text;
                gn = gn.ToUpper();
                gn = gn + sector3;


                detail.propertic(gn, gn0, bsc, bound);
                MessageBox.Show(detail.DCHNO);
                //if (detail.CGI == "" || detail.BSIC == "" || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")

                sw.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE=GSM900;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ",AGBLK=1;");
                sw.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                sw.WriteLine("RLCFI:CELL=" + gn + ",CHGR=0,DCHNO=" + detail.DCHNO + ";");
                sw.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw.WriteLine("RLIMI:CELL=" + gn + ";");
                sw.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB=" + detail.BSPWR + ";");
                sw.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=33,BSPWRT=" + detail.BSPWR + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw.WriteLine("RLLOC:CELL=" + gn + ",BSPWR=" + BSTXPWR + ",BSRXMIN=102,BSRXSUFF=110;");
                sw.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",IHO=OFF,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                sw.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                sw.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88;");

                sw.WriteLine("RLPCC:CELL=" + gn + ",QDESUL=20;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",REGINTUL=5;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",LCOMPUL=50;");
                sw.WriteLine("RLPCC:CELL=" + gn + ",QCOMPUL=60;");
                //sw.WriteLine("RLPCC:CELL=" + gn + ",DTXFUL=5;");

                sw.WriteLine("RLPCI:CELL=" + gn + ";");
                sw.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");

                sw.WriteLine("RLBCC:CELL=" + gn + ",SSDESDL=82;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SSLENDL=3;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",REGINTDL=1;");
                //sw.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF;");

                //sw.WriteLine("RLBCC:CELL=" + gn + ",QLENDL=5;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QDESDL=20;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",QCOMPDL=60;");
                sw.WriteLine("RLBCC:CELL=" + gn + ",BSPWRMINP=30;");


                sw.WriteLine("RLBCI:CELL=" + gn + ";");
                sw.WriteLine("RLLHC:CELL=" + gn + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=OFF;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=0,NUMREQBPC=" + detail.NUMREQBP_CH0 + ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLBDC:CELL=" + gn + ",CHGR=1,NUMREQBPC=" + detail.NUMREQBP_CH1+ ";");
                }
                //if (detail.NUMREQBP == "") MessageBox.Show("  را در فایل 84 دستی وارد کنید  NUMREQBP نیست لطفا GPRS در این ورژن امکان ایحاد دستورات ");
                sw.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=33,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=20,NECI=1,MBCR=2;");
                sw.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" + detail.SDCCH_CH0 + ",CBCH=NO,TN=1&&7;");
                sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0 + ",HSN=" + detail.HOP_CH0 + ";");
                if (detail.NUMREQBP_CH1 != "")
                {
                    sw.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH=" + detail.SDCCH_CH1 + ",CBCH=NO,TN=1&&7;");
                    sw.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP=" + detail.HOP_CH1 + ",HSN=" + detail.HSN_CH1+ ";");
                }
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");
                sw.WriteLine("RLSLI:CELL=" + gn + ";");
                sw.WriteLine("RLVLE:CHTYPE=TCH;");
                sw.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw.WriteLine("RLVLI:CHTYPE=TCH;");
                sw.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                sw.WriteLine("RLACI:CELL=" + gn + ";");
                sw.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40,HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
            }
            sw.Close();
            
            MessageBox.Show("The Files are created in Folder as:     D:\\DataBase_BSC\\84");

        }
        //--------------------------------------------------- 94 ----------------------------------
        //---------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false&& checkBox1.Checked == false)
                MessageBox.Show(" No Sector Selected");
            if (textBox3.Text == "" )
                MessageBox.Show(" The Code Side is not Curect");
            bound = "900";
            string gn = textBox3.Text;
            string gn0 = gn;
            string bsc = "";
            gn = gn.ToUpper();

            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\900");
            Create_Folder(@"D:\DataBase_BSC\86\900");
            Create_Folder(@"D:\DataBase_BSC\94\900");
            Create_Folder(@"D:\DataBase_BSC\eliminate");

            StreamWriter sw_94 = new StreamWriter("d:\\DataBase_BSC\\94\\900\\" + gn + "_94" + ".txt");

           // if (radioButton6.Checked) { bsc = "b176e"; }
           // if (radioButton5.Checked) { bsc = "b177e"; }
           // if (radioButton4.Checked) { bsc = "b178e"; }
           // if (radioButton1.Checked) { bsc = "b179e"; }

            detail.propertic(gn + "A", gn0, bsc, bound);
            string TG = textBox8.Text;
            string SOFWARE = "";
            int s = 2 * int.Parse(TG);
            string RXODPI = s.ToString();
            string DCP1 = "", DCP2 = "";
            SOFWARE = comboBox6.Text;
            if (SOFWARE == "Non")
            {
                SOFWARE = textBox16.Text;
                if (SOFWARE == "") MessageBox.Show("The SoftWare Ver. Was Not Identified");
            }
            

            sw_94.WriteLine("DTBLI:DIP=" + TG + "RBL2;");
            sw_94.WriteLine("DTIDP:DIP=" + TG + "RBL2;");
            sw_94.WriteLine("DTIDC:DIP=" + TG + "RBL2,CRC=0;");
            sw_94.WriteLine("DTFSC:DIP=" + TG + "RBL2,FAULT=1&2&3&4,ACL=A3;");
            sw_94.WriteLine("DTQSI:DIP=" + TG + "RBL2,SES,ES,SF;");
            sw_94.WriteLine("DTFSI:DIP=" + TG + "RBL2,FAULT=1&2&3&4;");
            sw_94.WriteLine("DTFSP:DIP=" + TG + "RBL2;");
            sw_94.WriteLine("DTQSP:DIP=" + TG + "RBL2;");
            sw_94.WriteLine("DTBLE:DIP=" + TG + "RBL2;");
            sw_94.WriteLine("RXMOI:MO=RXOTG-" + TG + ",COMB=HYB,RSITE="+textBox2.Text+ ",SWVER="+SOFWARE+";");
            sw_94.WriteLine("RXMOC:MO=RXOTG-" + TG + ",FHOP=BB,CONFMD=CMD,CONFACT=" + comboBox2.Text + ",TRACO=POOL;");
            sw_94.WriteLine("RXMOP:MO=RXOTG-" + TG + ";");
            sw_94.WriteLine("RXMOI:MO=RXOCF-" + TG + ",TEI=62,SIG=CONC;");
            sw_94.WriteLine("RXMOP:MO=RXOCF-" + TG + ";");
            sw_94.WriteLine("RXMOI:MO=RXOCON-" + TG + ",DCP=64&&87;");
            sw_94.WriteLine("RXMOI:MO=RXOTF-" + TG + ",TFMODE=SA;");
            sw_94.WriteLine("RXMOP:MO=RXOTF-" + TG + ";");
            sw_94.WriteLine("RXMOI:MO=RXOIS-" + TG + ";");
            sw_94.WriteLine("RXMOP:MO=RXOIS-" + TG + ";");
            sw_94.WriteLine("RXMOI:MO=RXODP-" + TG + "-0,DEV=RXODPI-" + RXODPI + ";");
            sw_94.WriteLine("RXMOP:MO=RXODP-" + TG + "-0;");
            sw_94.WriteLine("RLDEP:CELL=" + gn0 + "A;");

            if ((checkBox6.Checked == true))
            {
                sector1 = "A";
                string gna = gn + sector1;
                detail.propertic(gna, gn0, bsc, bound);

                if (textBox4.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_A = int.Parse(textBox4.Text);
                for (int r = 0; r < Number_of_TRX_A; r++)
                {
                    if (r == 0) { DCP1 = "128"; DCP2 = "129&130"; }
                    if (r == 1) { DCP1 = "131"; DCP2 = "132&133"; }
                    if (r == 2) { DCP1 = "134"; DCP2 = "135&136"; }
                    if (r == 3) { DCP1 = "137"; DCP2 = "138&139"; }
                    sw_94.WriteLine("RXMOI:MO=RXOTRX-" + TG + "-" + r + ",TEI=" + r + ",DCP1=" + DCP1 + ",DCP2=" + DCP2 + ",SIG=CONC;");
                    sw_94.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL=" + gn0 + "A;");
                    sw_94.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM900,MPWR=47;");
                    sw_94.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL=" + gn0 + "A;");
                    sw_94.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM900,RXD=AB;");
                    sw_94.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                }

            }

            if ((checkBox5.Checked == true))
            {
                sector2 = "B";
                string gnb = gn + sector2;
                detail.propertic(gnb, gn0, bsc, bound);

                if (textBox5.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_B = int.Parse(textBox5.Text);
                for (int r = 4; r < Number_of_TRX_B + 4; r++)
                {
                    if (r == 4) { DCP1 = "140"; DCP2 = "141&142"; }
                    if (r == 5) { DCP1 = "143"; DCP2 = "144&145"; }
                    if (r == 6) { DCP1 = "160"; DCP2 = "161&162"; }
                    if (r == 7) { DCP1 = "163"; DCP2 = "164&165"; }
                    sw_94.WriteLine("RXMOI:MO=RXOTRX-" + TG + "-" + r + ",TEI=" + r + ",DCP1=" + DCP1 + ",DCP2=" + DCP2 + ",SIG=CONC;");
                    sw_94.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL=" + gn0+ "B;");
                    sw_94.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM900,MPWR=47;");
                    sw_94.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL=" + gn0 + "B;");
                    sw_94.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM900,RXD=AB;");
                    sw_94.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                }

            }
            if ((checkBox4.Checked == true))
            {
                sector3 = "C";
                string gnb = gn + sector3;
                detail.propertic(gnb, gn0, bsc, bound);

                if (textBox4.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_C = int.Parse(textBox6.Text);
                for (int r = 8; r < Number_of_TRX_C + 8; r++)
                {
                    if (r == 8) { DCP1 = "166"; DCP2 = "167&168"; }
                    if (r == 9) { DCP1 = "169"; DCP2 = "170&171"; }
                    if (r == 10) { DCP1 = "172"; DCP2 = "173&174"; }
                    if (r == 11) { DCP1 = "175"; DCP2 = "176&177"; }
                    sw_94.WriteLine("RXMOI:MO=RXOTRX-" + TG + "-" + r + ",TEI=" + r + ",DCP1=" + DCP1 + ",DCP2=" + DCP2 + ",SIG=CONC;");
                    sw_94.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL=" + gn0 + "C;");
                    sw_94.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM900,MPWR=47;");
                    sw_94.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL=" + gn0 + "C;");
                    sw_94.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM900,RXD=AB;");
                    sw_94.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                }

            }
            int a = int.Parse(TG) * 32 + 1;
            int b = int.Parse(TG) * 32 + 30 + 1;
            sw_94.WriteLine("RXAPI:MO=RXOTG-" + TG + ",DEV=RBLT2-" + textBox29.Text + "&&-" + textBox28.Text + ",DCP=1&&31;");
            sw_94.WriteLine("RXAPP:MO=RXOTG-" + TG + ";");
            sw_94.WriteLine("DTDII:DIP=ODPI" + RXODPI + ",DEV=RXODPI-" + RXODPI + ";");
            sw_94.WriteLine("DTIDP:DIP=ODPI" + RXODPI + ";");
            sw_94.WriteLine("DTIDC:DIP=ODPI" + RXODPI + ",CRC=0;");
            sw_94.WriteLine("DTFSC:DIP=ODPI" + RXODPI + ",FAULT=1&2&3&4&9,ACL=A3;");
            sw_94.WriteLine("DTQSC:DIP=ODPI" + RXODPI + ",BFF,BFFL1=100,ACL1=A3,BFFL2=800,ACL2=A2;");
            sw_94.WriteLine("DTQSC:DIP=ODPI" + RXODPI + ",SF,SFL=5,TI=24,ACL=A3;");
            sw_94.WriteLine("DTQSC:DIP=ODPI" + RXODPI + ",DF,DFL=5,TI=24,ACL=A3;");
            sw_94.WriteLine("DTQSI:DIP=ODPI" + RXODPI + ",BFF,LL,LH,SF,DF;");

            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "A" + ",CHGR=0;");
            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "B" + ",CHGR=0;");
            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "C" + ",CHGR=0;");

            if(textBox4.Text=="4")
            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "A" + ",CHGR=1;");
            if(textBox5.Text=="4")
            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "B" + ",CHGR=1;");
            if(textBox6.Text=="4")
            sw_94.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn + "C" + ",CHGR=1;");

            sw_94.WriteLine("RXTCP:MO=RXOTG-" + TG + ";");
            sw_94.WriteLine("DTSTP:DIP=" + TG + "RBL2;!DIPMUST BE WORKING!");
            sw_94.WriteLine("DTSTP:DIP=ODPI" + RXODPI + ";");
            sw_94.WriteLine("DTBLE:DIP=ODPI" + RXODPI + ";!DIPKEEPS ABL UNTIL MO=RXODP IS WORKING!");
            sw_94.WriteLine("STDEP:DEV=RBLT2-" + textBox29.Text + "&&-" + textBox28.Text + ";");
            sw_94.WriteLine("EXDAI:DEV=RBLT2-" + textBox29.Text + "&&-" + textBox28.Text + ";");
            sw_94.WriteLine("BLODE:DEV=RBLT2-" +textBox29.Text + "&&-" + textBox28.Text +";");
            sw_94.WriteLine("RXESI:MO=RXOTG-" + TG + ",subord;");
            sw_94.WriteLine("RXMSP:MO=RXOTG-" + TG + ",subord;");
            sw_94.WriteLine("RXBLE:MO=RXOTG-" + TG + ",subord;");


            sw_94.WriteLine("RLSTC:CELL=" + gn + "A" + ",STATE=ACTIVE;");
            sw_94.WriteLine("RLSTP:CELL=" + gn + "A" + ";");
            sw_94.WriteLine("RLCRP:CELL=" + gn + "A" + ";");


            sw_94.WriteLine("RLSTC:CELL=" + gn + "B" + ",STATE=ACTIVE;");
            sw_94.WriteLine("RLSTP:CELL=" + gn + "B" + ";");
            sw_94.WriteLine("RLCRP:CELL=" + gn + "B" + ";");


            sw_94.WriteLine("RLSTC:CELL=" + gn + "C" + ",STATE=ACTIVE;");
            sw_94.WriteLine("RLSTP:CELL=" + gn + "C" + ";");
            sw_94.WriteLine("RLCRP:CELL=" + gn + "C" + ";");
            sw_94.WriteLine("RXCDP:MO=RXOTG-" + TG + ";");

            MessageBox.Show("DataBase File is create");
            textBox8.Text = "";
            sw_94.Close();
            MessageBox.Show("The File is created in Folder as:     D:\\DataBase_BSC\\94");
        }
        //---------------------------------------------------------------------------------
        //--------------------------- button3 -------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            string gn0 = textBox7.Text;
            string bsc = "", bcch = "", bsic = "", bsc_c = "", bsc_border = "";
            int c = 0;
            string cell_bcch = "";

            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\900");
            Create_Folder(@"D:\DataBase_BSC\86\900");
            Create_Folder(@"D:\DataBase_BSC\94\900");
            Create_Folder(@"D:\DataBase_BSC\eliminate");

            dataGridView1.Rows.Clear();
            if (radioButton7.Checked == true) bsc_border = "b176e";
            if (radioButton8.Checked == true) bsc_border = "b177e";
            if (radioButton9.Checked == true) bsc_border = "b178e";
            if (radioButton22.Checked == true) bsc_border = "b179e";
            if (radioButton2.Checked == true) bsc_border = "b180e";
            StreamWriter nb176 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\176" + gn0 + "_86" + ".txt");
            StreamWriter nb177 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\177" + gn0 + "_86" + ".txt");
            StreamWriter nb178 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\178" + gn0 + "_86" + ".txt");
            StreamWriter nb179 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\179" + gn0 + "_86" + ".txt");
            StreamWriter nb180 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\180" + gn0 + "_86" + ".txt");

            //------------------------------------------ sector A----------------------------
            if (checkBox7.Checked == true)
            {

                string gna = gn0 + "A";
                gna = gna.ToUpper();
                hamsaeh.neyber(gna);
                bsc_c = hamsaeh.cell_bsc;

                bound = "";
                detail.propertic(gna, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                c = 0;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)  c++; }
                string[] cellra = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellra[j] = detail.CELLR[j];
                dataGridView1.Rows.Add("");
                dataGridView1.Rows.Add("", gna, "", detail.BCCH, bsc_c);
                bsc_c = "";
                for (int j = 1; j < cellra.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellra[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');

                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];
                            }
                        }
                    }

                    hamsaeh.neyber(cellra[j]);
                    dataGridView1.Rows.Add("", "", cellra[j], bcch, hamsaeh.cell_bsc);

                    // ------------------ B176E ---------------------------
                    if (radioButton7.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");

                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            
                            nb176.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");


                            if (hamsaeh.cell_bsc == "b177e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton8.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton9.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }

                    //---------------------------------------- BSC border 179 -------------
                    if (radioButton22.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }

                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }

                    //---------------------------------------- BSC border 180 -------------
                    if (radioButton2.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }

                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                        }

                    }

                }
                //-----------------------------------------------------------------------

                // ---------------------------------------------------------
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
            }
            //-------------------------------- sector B -------------------------------------

            if (checkBox8.Checked == true)
            {
                string gnb = gn0 + "B";
                gnb = gnb.ToUpper();
                hamsaeh.neyber(gnb);
                bsc_c = hamsaeh.cell_bsc;
                bound = "";
                detail.propertic(gnb, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                c = 0;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)  c++; }
                string[] cellrb = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellrb[j] = detail.CELLR[j];
                dataGridView1.Rows.Add("");
                dataGridView1.Rows.Add("", gnb, "", detail.BCCH, bsc_c);
                bsc_c = "";
                for (int j = 1; j < cellrb.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellrb[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');
                                bsic = gn_rldep[6];
                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];

                            }
                        }
                    }
                    hamsaeh.neyber(cellrb[j]);
                    if (cellrb[j].StartsWith("MA"))
                    {
                        detail.propertic(cellrb[j], gn0, bsc, bound);
                        string a = detail.BCCH;
                    }
                    dataGridView1.Rows.Add("", "", cellrb[j], bcch, hamsaeh.cell_bsc);
                    //000000000000000------------------
                    if (radioButton7.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb176.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");


                            if (hamsaeh.cell_bsc == "b177e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton8.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton9.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");
                          
                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 179 -------------
                    if (radioButton22.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 180 -------------
                    if (radioButton2.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                        }

                    }

                }
                //-----------------------------------------------------------------------

                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
            }
            //------------------------------ sectore C -------------------------
            //---------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------------

            if (checkBox9.Checked == true)
            {
                string gnc = gn0 + "C";
                gnc = gnc.ToUpper();
                hamsaeh.neyber(gnc);
                bsc_c = hamsaeh.cell_bsc;
                c = 0;
                bound = "";
                detail.propertic(gnc, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)   c = c + 1; }
                string[] cellrc = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellrc[j] = detail.CELLR[j];
                dataGridView1.Rows.Add("");
                dataGridView1.Rows.Add("", gnc, "", detail.BCCH, bsc_c);
                bsc_c="";

                for (int j = 1; j < cellrc.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellrc[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');
                                bsic = gn_rldep[6];
                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];
                            }
                        }
                    }

                    hamsaeh.neyber(cellrc[j]);
                    dataGridView1.Rows.Add("", "", cellrc[j], bcch, hamsaeh.cell_bsc);
                    //000000000000000---------------------     b176e  border ---------------------------------------------
                    if (radioButton7.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");

                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb176.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");

                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton8.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE=" + detail.GSM_bound + " , EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 179 ------------------
                    if (radioButton22.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE=" + detail.GSM_bound + " , EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton9.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }

                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC  180 -------------
                    if (radioButton2.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }

                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                        }

                    }

                }
                //-----------------------------------------------------------------------

                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
            }

            nb176.Close();
            nb177.Close();
            nb178.Close();
            nb179.Close();
            nb180.Close();
          
            string[] b176 = File.ReadAllLines("D:\\DataBase_BSC\\86\\900\\176" + gn0 + "_86" + ".txt");
            string[] b177 = File.ReadAllLines("D:\\DataBase_BSC\\86\\900\\177" + gn0 + "_86" + ".txt");
            string[] b178 = File.ReadAllLines("D:\\DataBase_BSC\\86\\900\\178" + gn0 + "_86" + ".txt");
            string[] b179 = File.ReadAllLines("D:\\DataBase_BSC\\86\\900\\179" + gn0 + "_86" + ".txt");
            string[] b180 = File.ReadAllLines("D:\\DataBase_BSC\\86\\900\\180" + gn0 + "_86" + ".txt");

            if (b176.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\900\\176" + gn0 + "_86" + ".txt"); }
            if (b177.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\900\\177" + gn0 + "_86" + ".txt"); }
            if (b178.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\900\\178" + gn0 + "_86" + ".txt"); }
            if (b179.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\900\\179" + gn0 + "_86" + ".txt"); }
            if (b180.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\900\\180" + gn0 + "_86" + ".txt"); }



            if (File.Exists("D:\\DataBase_BSC\\86\\900\\176" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe176 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\176" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b176.Length; p++)
                {
                    string tempt = b176[p];
                    for (int f = p + 1; f < b176.Length; f++)
                    {
                        if (b176[f] == tempt)
                            b176[f] = "";
                    }
                }
                for (int q = 0; q < b176.Length; q++)
                {
                    if (b176[q] != "")
                        nbe176.WriteLine(b176[q]);
                }
                nbe176.Close();
            }
                

            //---------------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\900\\177" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe177 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\177" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b177.Length; p++)
                {
                    string tempt = b177[p];
                    for (int f = p + 1; f < b177.Length; f++)
                    {
                        if (b177[f] == tempt)
                            b177[f] = "";
                    }
                }
                for (int q = 0; q < b177.Length; q++)
                {
                    if (b177[q] != "")
                        nbe177.WriteLine(b177[q]);
                }
                nbe177.Close();
            }
           
            //-------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\900\\178" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe178 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\178" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b178.Length; p++)
                {
                    string tempt = b178[p];
                    for (int f = p + 1; f < b178.Length; f++)
                    {
                        if (b178[f] == tempt)
                            b178[f] = "";
                    }
                }
                for (int q = 0; q < b178.Length; q++)
                {
                    if (b178[q] != "")
                        nbe178.WriteLine(b178[q]);
                }
                nbe178.Close();
            }
            //----------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\900\\179" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe179 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\179" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b179.Length; p++)
                {
                    string tempt = b179[p];
                    for (int f = p + 1; f < b179.Length; f++)
                    {
                        if (b179[f] == tempt)
                            b179[f] = "";
                    }
                }
                for (int q = 0; q < b179.Length; q++)
                {
                    if (b179[q] != "")
                        nbe179.WriteLine(b179[q]);
                }
                nbe179.Close();
            }
            //-------------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\900\\180" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe180 = new StreamWriter("D:\\DataBase_BSC\\86\\900\\180" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b180.Length; p++)
                {
                    string tempt = b180[p];
                    for (int f = p + 1; f < b180.Length; f++)
                    {
                        if (b180[f] == tempt)
                            b180[f] = "";
                    }
                }
                for (int q = 0; q < b180.Length; q++)
                {
                    if (b180[q] != "")
                        nbe180.WriteLine(b180[q]);
                }
                nbe180.Close();
            }
            MessageBox.Show("The Files are created in Folder as:     D:\\DataBase_BSC\\86");
        }
// ----------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {

            //int Se_A = 0, Se_B = 0, Se_C = 0;
            string gn = "";
            string tg = "";
            int odpi = 0;
            tg = textBox9.Text;
            gn = textBox10.Text;
            odpi = (int.Parse(tg))*2;
            StreamWriter elminate = new StreamWriter("D:\\DataBase_BSC\\eliminate\\" + gn + ".txt");
            elminate.WriteLine("rxbli:mo=rxotg-" + tg + ",subord,force;");
            elminate.WriteLine("rxese:mo=rxotg-" + tg + ",subord;");
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-0-0&&-7;");
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-1-0&&-7;");
            if (comboBox1.Text == "4")
            {
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-2-0&&-7;");
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-3-0&&-7;");
            }
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-4-0&&-7;");
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-5-0&&-7;");
            if (comboBox3.Text == "4")
            {
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-6-0&&-7;");
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-7-0&&-7;");
            }
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-8-0&&-7;");
            elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-9-0&&-7;");
            if (comboBox4.Text == "4")
            {
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-10-0&&-7;");
                elminate.WriteLine("rxmoe:mo=rxots-" + tg + "-11-0&&-7;");
            }



            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-0;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-1;");
            if(comboBox1.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-2;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-3;");
            }
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-4;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-5;");
            if(comboBox3.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-6;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-7;");
            }    
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-8;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-9;");
            if(comboBox4.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-10;");
            elminate.WriteLine("rxmoe:mo=rxotx-" + tg + "-11;");
            }

            //ORX
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-0;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-1;");
            if(comboBox1.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-2;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-3;");
            }
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-4;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-5;");
            if(comboBox3.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-6;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-7;");
            }    
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-8;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-9;");
            if(comboBox4.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-10;");
            elminate.WriteLine("rxmoe:mo=rxorx-" + tg + "-11;");
            }


            //rxotrx
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-0;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-1;");
            if(comboBox1.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-2;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-3;");
            }
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-4;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-5;");
            if(comboBox3.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-6;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-7;");
            }    
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-8;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-9;");
            if(comboBox4.Text=="4")
            {
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-10;");
            elminate.WriteLine("rxmoe:mo=rxotrx-" + tg + "-11;");
            }

            elminate.WriteLine("rxmoe:mo=rxocon-"+tg+";");
            elminate.WriteLine("rxmoe:mo=rxois-"+tg+";");
            elminate.WriteLine("rxmoe:mo=rxotf-"+tg+";");
            elminate.WriteLine("rxmoe:mo=rxocf-"+tg+";");

            elminate.WriteLine("dtbli:dip=odpi"+odpi+";");
            elminate.WriteLine("dtdie:dip=odpi"+odpi+";");
            elminate.WriteLine("rxmoe:mo=rxodp-"+tg+"-0;");
            elminate.WriteLine("rxape:mo=rxotg-"+tg+",dcp=1&&31;");
            elminate.WriteLine("rlstc:cell="+gn+"a,state=halted;");
            elminate.WriteLine("rlstc:cell="+gn+"b,state=halted;");
            elminate.WriteLine("rlstc:cell="+gn+"c,state=halted;");
            elminate.WriteLine("rxtce:mo=rxotg-"+tg+",cell="+gn+"a,chgr=0;");
            elminate.WriteLine("rxtce:mo=rxotg-"+tg+",cell="+gn+"b,chgr=0;");
            elminate.WriteLine("rxtce:mo=rxotg-"+tg+",cell="+gn+"c,chgr=0;");
            elminate.WriteLine("rxmoe:mo=rxotg-" + tg + ";");
            elminate.WriteLine("rlvle: chtype = tch;");
            elminate.WriteLine("rlvle: chtype = sdcch;");
            elminate.WriteLine("rlvle:cell=" + gn + "a,chtype=tch;");
            elminate.WriteLine("rlvle:cell=" + gn + "b,chtype=tch;");
            elminate.WriteLine("rlvle:cell=" + gn + "c,chtype=tch;");
            elminate.WriteLine("rlvle:cell=" + gn + "a,chtype=sdcch;");
            elminate.WriteLine("rlvle:cell=" + gn + "b,chtype=sdcch;");
            elminate.WriteLine("rlvle:cell=" + gn + "c,chtype=sdcch;");
            elminate.WriteLine("rlsle:cell=" + gn + "a,perm;");
            elminate.WriteLine("rlsle:cell=" + gn + "b,perm;");
            elminate.WriteLine("rlsle:cell=" + gn + "c,perm;");
            elminate.WriteLine("rldee:cell=" + gn + "a;");
            elminate.WriteLine("rldee:cell=" + gn + "b;");
            elminate.WriteLine("rldee:cell=" + gn + "c;");


            MessageBox.Show("Eliminate file is create");
            elminate.Close();
            textBox9.Text = "";
            textBox10.Text = "";
        }
        // ---------- 86 for 1800 ----------
        //------------------------------------
        //--------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {

           string gn0 = textBox14.Text;
            string bsc = "", bcch = "", bsic = "", bsc_c = "", bsc_border = "";
            int c = 0;
            string cell_bcch = "";
            dataGridView5.Rows.Clear();
            if (radioButton21.Checked == true) bsc_border = "b176e";
            if (radioButton20.Checked == true) bsc_border = "b177e";
            if (radioButton19.Checked == true) bsc_border = "b178e";
            if (radioButton1.Checked == true) bsc_border = "b179e";
            if (radioButton3.Checked == true) bsc_border = "b180e";
            StreamWriter nb176 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\176" + gn0 + "_86" + ".txt");
            StreamWriter nb177 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\177" + gn0 + "_86" + ".txt");
            StreamWriter nb178 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\178" + gn0 + "_86" + ".txt");
            StreamWriter nb179 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\179" + gn0 + "_86" + ".txt");
            StreamWriter nb180 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\180" + gn0 + "_86" + ".txt");

            //------------------------------------------ sector A----------------------------
            if (checkBox21.Checked == true)
            {

                string gna = gn0 + "D";
                gna = gna.ToUpper();
                hamsaeh.neyber(gna);
                bsc_c = hamsaeh.cell_bsc;

                bound = "";
                detail.propertic(gna, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                c = 0;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)  c++; }
                string[] cellra = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellra[j] = detail.CELLR[j];
                dataGridView5.Rows.Add("");
                dataGridView5.Rows.Add("", gna, "", detail.BCCH, bsc_c);
                bsc_c = "";
                for (int j = 1; j < cellra.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellra[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');

                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];
                            }
                        }
                    }

                    hamsaeh.neyber(cellra[j]);
                    dataGridView5.Rows.Add("", "", cellra[j], bcch, hamsaeh.cell_bsc);

                    //000000000000000------------------
                    if (radioButton21.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");

                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb176.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");


                            if (hamsaeh.cell_bsc == "b177e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton20.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton19.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
//--------------------------------------------- BSC border 179 --------------------
                    if (radioButton1.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //--------------------------------------------- BSC border 180 --------------------
                    if (radioButton3.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gna + ",CELLR=" + cellra[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellra[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellra[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellra[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellra[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellra[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellra[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gna + ",CELLR=" + cellra[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gna + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gna, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gna, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gna + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gna + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gna + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gna + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gna + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellra[j] + ",CELLR=" + gna + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellra[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                        }

                    }
                }
                //-----------------------------------------------------------------------

                // ---------------------------------------------------------
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
            }
            //-------------------------------- sector B -------------------------------------

            if (checkBox20.Checked == true)
            {
                string gnb = gn0 + "E";
                gnb = gnb.ToUpper();
                hamsaeh.neyber(gnb);
                bsc_c = hamsaeh.cell_bsc;
                bound = "";
                detail.propertic(gnb, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                c = 0;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)  c++; }
                string[] cellrb = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellrb[j] = detail.CELLR[j];
                dataGridView5.Rows.Add("");
                dataGridView5.Rows.Add("", gnb, "", detail.BCCH, bsc_c);
                bsc_c = "";
                for (int j = 1; j < cellrb.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellrb[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');
                                bsic = gn_rldep[6];
                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];

                            }
                        }
                    }
                    hamsaeh.neyber(cellrb[j]);
                    if (cellrb[j].StartsWith("MA"))
                    {
                        detail.propertic(cellrb[j], gn0, bsc, bound);
                        string a = detail.BCCH;
                    }
                    dataGridView5.Rows.Add("", "", cellrb[j], bcch, hamsaeh.cell_bsc);
                    //000000000000000------------------
                    if (radioButton21.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");

                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb176.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");


                            if (hamsaeh.cell_bsc == "b177e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton20.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton19.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");
                          
                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 179 -------------
                    if (radioButton1.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 180 -------------
                    if (radioButton3.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellrb[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellrb[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellrb[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellrb[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellrb[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellrb[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gnb + ",CELLR=" + cellrb[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gnb + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnb, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {

                                detail.propertic(gnb, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnb + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnb + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnb + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnb + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnb + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrb[j] + ",CELLR=" + gnb + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrb[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                        }

                    }
                }
                //-----------------------------------------------------------------------

                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
            }
            //------------------------------ sectore C -------------------------
            //---------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------------

            if (checkBox19.Checked == true)
            {
                string gnc = gn0 + "F";
                gnc = gnc.ToUpper();
                hamsaeh.neyber(gnc);
                bsc_c = hamsaeh.cell_bsc;
                c = 0;
                bound = "";
                detail.propertic(gnc, gn0, bsc, bound);
                cell_bcch = detail.BCCH;
                for (int t = 0; t < 32; t++) { if (detail.CELLR[t] != null)   c = c + 1; }
                string[] cellrc = new string[c + 1];
                for (int j = 0; j < c + 1; j++) cellrc[j] = detail.CELLR[j];
                dataGridView5.Rows.Add("");
                dataGridView5.Rows.Add("", gnc, "", detail.BCCH, bsc_c);
                bsc_c="";

                for (int j = 1; j < cellrc.Length; j++)
                {
                    if (File.Exists(@"d:\DataBase_BSC\rldep.txt"))
                    {
                        string[] line_rldep = File.ReadAllLines(@"d:\DataBase_BSC\rldep.txt");
                        for (int i = 0; i < line_rldep.Length; i++)
                        {
                            if (line_rldep[i].StartsWith(cellrc[j]))
                            {
                                string[] gn_rldep = line_rldep[i].Split(' ');
                                bsic = gn_rldep[6];
                                if (gn_rldep.Length > 12)
                                {
                                    if (gn_rldep[12] != "") bcch = gn_rldep[12];
                                    else bcch = gn_rldep[11];
                                }
                                else bcch = gn_rldep[11];
                            }
                        }
                    }

                    hamsaeh.neyber(cellrc[j]);
                    dataGridView5.Rows.Add("", "", cellrc[j], bcch, hamsaeh.cell_bsc);
                    //000000000000000---------------------     b176e  border ---------------------------------------------
                    if (radioButton21.Checked == true)
                    {
                        if (hamsaeh.cell_bsc == "b176e")
                        {

                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb176.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb176.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb176.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb176.WriteLine("");

                        }
                        if (hamsaeh.cell_bsc != "b176e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb176.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb176.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb176.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb176.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb176.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb176.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb176.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb176.WriteLine("");
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");

                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //-------------------------------- BSC border 177 ------------------
                    if (radioButton20.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b177e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb177.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb177.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb177.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb177.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b177e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb177.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE=" + detail.GSM_bound + " , EXT;");
                            nb177.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                            nb177.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb177.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb177.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb177.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb177.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb177.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ", BSIC=" + detail.BSIC + ", BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");

                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }
                    //---------------------------------------- BSC border 178 -------------
                    if (radioButton19.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b178e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb178.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb178.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb178.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb178.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b178e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb178.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb178.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb178.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb178.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb178.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb178.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb178.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb178.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }

                    //---------------------------------------- BSC border 179 -------------
                    if (radioButton1.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b179e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb179.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb179.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb179.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb179.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b179e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb179.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE="+detail.GSM_bound+", EXT;");
                            nb179.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb179.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb179.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb179.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb179.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb179.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb179.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE="+detail.GSM_bound+",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b180e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb180.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb180.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb180.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb180.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb180.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb180.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb180.WriteLine("");
                            }
                        }

                    }

                    //---------------------------------------- BSC border 180 -------------
                    if (radioButton3.Checked == true)
                    {

                        if (hamsaeh.cell_bsc == "b180e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb180.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ";");
                            nb180.WriteLine("RLNRC:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",CS=NO,AWOFFSET=10;");
                            nb180.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + bcch + ",MRNIC;");
                            nb180.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + cell_bcch + ",MRNIC;");
                            nb180.WriteLine("");
                        }
                        if (hamsaeh.cell_bsc != "b180e")
                        {
                            detail.propertic(cellrc[j], gn0, bsc, bound);
                            nb180.WriteLine("RLDEI:CELL=" + cellrc[j] + ",CSYSTYPE=" + detail.GSM_bound + ", EXT;");
                            nb180.WriteLine("RLDEC:CELL=" + cellrc[j] + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                            nb180.WriteLine("RLLOC:CELL=" + cellrc[j] + ",BSPWR=37, BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                            nb180.WriteLine("RLCPC:CELL=" + cellrc[j] + ",MSTXPWR=33;");
                            nb180.WriteLine("RLLHC:CELL=" + cellrc[j] + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                            nb180.WriteLine("RLNRI:CELL=" + gnc + ",CELLR=" + cellrc[j] + ",SINGLE;");
                            nb180.WriteLine("RLMFC:CELL=" + gnc + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                            nb180.WriteLine("");

                            if (hamsaeh.cell_bsc == "b176e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb176.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb176.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb176.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb176.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb176.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb176.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb176.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb176.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b177e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb177.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb177.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb177.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb177.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb177.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb177.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb177.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb177.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b178e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb178.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb178.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb178.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb178.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb178.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb178.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb178.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb178.WriteLine("");
                            }
                            if (hamsaeh.cell_bsc == "b179e")
                            {
                                detail.propertic(gnc, gn0, bsc, bound);
                                nb179.WriteLine("RLDEI:CELL=" + gnc + ",CSYSTYPE=" + detail.GSM_bound + ",EXT;");
                                nb179.WriteLine("RLDEC:CELL=" + gnc + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ";");
                                nb179.WriteLine("RLLOC:CELL=" + gnc + ",BSPWR=37,BSRXMIN=120,BSRXSUFF=0,MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,MISSNM=3,AW=OFF,BSTXPWR=35,EXTPEN=OFF;");
                                nb179.WriteLine("RLCPC:CELL=" + gnc + ",MSTXPWR=33;");
                                nb179.WriteLine("RLLHC:CELL=" + gnc + ",LAYER=6,LAYERTHR=75,LAYERHYST=2,PSSTEMP=10,PTIMTEMP=5,FASTMSREG=ON;");
                                nb179.WriteLine("RLNRI:CELL=" + cellrc[j] + ",CELLR=" + gnc + ",SINGLE;");
                                nb179.WriteLine("RLMFC:CELL=" + cellrc[j] + ",MBCCHNO=" + detail.BCCH + ",MRNIC;");
                                nb179.WriteLine("");
                            }
                        }

                    }

                }
                //-----------------------------------------------------------------------

                if (detail.CELLR[0] == "") { MessageBox.Show(" There is no Neyber"); }
                for (int t = 0; t < 32; t++) { detail.CELLR[t] = null; }
            }
          
            nb178.Close();
            nb177.Close();
            nb176.Close();
            nb179.Close();
            nb180.Close();


            string[] b176 = File.ReadAllLines("D:\\DataBase_BSC\\86\\1800\\176" + gn0 + "_86" + ".txt");
            string[] b177 = File.ReadAllLines("D:\\DataBase_BSC\\86\\1800\\177" + gn0 + "_86" + ".txt");
            string[] b178 = File.ReadAllLines("D:\\DataBase_BSC\\86\\1800\\178" + gn0 + "_86" + ".txt");
            string[] b179 = File.ReadAllLines("D:\\DataBase_BSC\\86\\1800\\179" + gn0 + "_86" + ".txt");
            string[] b180 = File.ReadAllLines("D:\\DataBase_BSC\\86\\1800\\180" + gn0 + "_86" + ".txt");

            if (b176.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\1800\\176" + gn0 + "_86" + ".txt"); }
            if (b177.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\1800\\177" + gn0 + "_86" + ".txt"); }
            if (b178.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\1800\\178" + gn0 + "_86" + ".txt"); }
            if (b179.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\1800\\179" + gn0 + "_86" + ".txt"); }
            if (b180.Length == 0) { File.Delete("D:\\DataBase_BSC\\86\\1800\\180" + gn0 + "_86" + ".txt"); }



            if (File.Exists("D:\\DataBase_BSC\\86\\1800\\176" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe176 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\176" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b176.Length; p++)
                {
                    string tempt = b176[p];
                    for (int f = p + 1; f < b176.Length; f++)
                    {
                        if (b176[f] == tempt)
                            b176[f] = "";
                    }
                }
                for (int q = 0; q < b176.Length; q++)
                {
                    if (b176[q] != "")
                        nbe176.WriteLine(b176[q]);
                }
                nbe176.Close();
            }
                

            //---------------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\1800\\177" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe177 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\177" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b177.Length; p++)
                {
                    string tempt = b177[p];
                    for (int f = p + 1; f < b177.Length; f++)
                    {
                        if (b177[f] == tempt)
                            b177[f] = "";
                    }
                }
                for (int q = 0; q < b177.Length; q++)
                {
                    if (b177[q] != "")
                        nbe177.WriteLine(b177[q]);
                }
                nbe177.Close();
            }
           
            //-------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\1800\\178" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe178 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\178" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b178.Length; p++)
                {
                    string tempt = b178[p];
                    for (int f = p + 1; f < b178.Length; f++)
                    {
                        if (b178[f] == tempt)
                            b178[f] = "";
                    }
                }
                for (int q = 0; q < b178.Length; q++)
                {
                    if (b178[q] != "")
                        nbe178.WriteLine(b178[q]);
                }
                nbe178.Close();
            }

            //-------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\1800\\179" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe179 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\179" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b179.Length; p++)
                {
                    string tempt = b179[p];
                    for (int f = p + 1; f < b179.Length; f++)
                    {
                        if (b179[f] == tempt)
                            b179[f] = "";
                    }
                }
                for (int q = 0; q < b179.Length; q++)
                {
                    if (b179[q] != "")
                        nbe179.WriteLine(b179[q]);
                }
                nbe179.Close();
            }

            //-------------------------------------
            if (File.Exists("D:\\DataBase_BSC\\86\\1800\\180" + gn0 + "_86" + ".txt"))
            {
                StreamWriter nbe180 = new StreamWriter("D:\\DataBase_BSC\\86\\1800\\180" + gn0 + "_86" + ".txt");
                for (int p = 0; p < b180.Length; p++)
                {
                    string tempt = b180[p];
                    for (int f = p + 1; f < b180.Length; f++)
                    {
                        if (b180[f] == tempt)
                            b180[f] = "";
                    }
                }
                for (int q = 0; q < b180.Length; q++)
                {
                    if (b180[q] != "")
                        nbe180.WriteLine(b180[q]);
                }
                nbe180.Close();
            }
            MessageBox.Show("The File is created in Folder as:     D:\\DataBase_BSC\\86");
        }
        //----------------------------------------------------------------------------------------------
        public void Create_Folder(string Path)
        {
            if (!System.IO.Directory.Exists(Path))
            {
                System.IO.Directory.CreateDirectory(Path);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
        
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.CheckFileExists = true;
            myOpenFileDialog.DefaultExt = "txt";
            myOpenFileDialog.InitialDirectory = @"d:\";
            myOpenFileDialog.Multiselect = false;
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox15.Text = myOpenFileDialog.FileName;
            }
        }

   

        private void button11_Click(object sender, EventArgs e)
        {
            
            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\1800");
            Create_Folder(@"D:\DataBase_BSC\86\1800");
            Create_Folder(@"D:\DataBase_BSC\94\1800");
            Create_Folder(@"D:\DataBase_BSC\eliminate");
            int w=0;
//////////////////// RLDEP -----------------------
            if (string.Compare(comboBox5.Text,"RLDEP")==0)
            {
                if (textBox15.Text !="")
                {
                    string[] temp = File.ReadAllLines(@textBox15.Text);
                    StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rldep.txt");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].StartsWith("END")) temp[i] = ""; 
                        temp_file.WriteLine(temp[i]);
                        if (string.Compare(temp[i], "CELL     CGI                  BSIC  BCCHNO  AGBLK  MFRMS  IRC") == 0)
                            w = w + 1;
                    }
                    temp_file.WriteLine("GN");
                    temp_file.Close();
                    if (w == 0)
                    {
                        MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                        File.Delete(@"D:\\DataBase_BSC\\rldep.txt");
                    }
                }
                //else
                    //MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
///////////////////////////////////////////////////////////////
    //////////////////// RLNRP -------------------------
            if (string.Compare(comboBox5.Text,"RLNRP")==0)
            {
                if (textBox15.Text != "")
                {
                    string[] temp = File.ReadAllLines(@textBox15.Text);
                    StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlnrp.txt");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].StartsWith("END")) temp[i] = ""; 
                        temp_file.WriteLine(temp[i]);
                        if (string.Compare(temp[i], "CELLR     DIR     CAND   CS") == 0)
                            w = w + 1;
                    }
                    temp_file.WriteLine("CELL");
                    temp_file.Close();
                    if (w == 0)
                    {
                        MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                        File.Delete(@"D:\\DataBase_BSC\\rlnrp.txt");
                    }
                }
               // else
                  //  MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
///////////////////////////////////////////////////////////////
               //////////////////// RLMFP -------------------------
               if (string.Compare(comboBox5.Text,"RLMFP")==0)
               {
                   if (textBox15.Text != "")
                   {
                       string[] temp = File.ReadAllLines(@textBox15.Text);
                       StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlmfp.txt");
                       for (int i = 0; i < temp.Length; i++)
                       {
                           if (temp[i].StartsWith("END")) temp[i] = ""; 
                           temp_file.WriteLine(temp[i]);
                           if (string.Compare(temp[i], "MBCCHNO") == 0)
                               w = w + 1;
                       }
                       temp_file.WriteLine("GN");
                       temp_file.Close();
                       if (w == 0)
                       {
                           MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                           File.Delete(@"D:\\DataBase_BSC\\rlmfp.txt");
                       }
                   }
                  // else
                     //  MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
///////////////////////////////////////////////////////////////
               //////////////////// RLCFP -------------------------
               if (string.Compare(comboBox5.Text,"RLCFP")==0)
               {
                   if (textBox15.Text != "")
                   {
                       string[] temp = File.ReadAllLines(@textBox15.Text);
                       StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlcfp.txt");
                       for (int i = 0; i < temp.Length; i++)
                       {
                           if (temp[i].StartsWith("END")) temp[i] = ""; 
                           temp_file.WriteLine(temp[i]);
                           if (string.Compare(temp[i], "CHGR   SCTYPE    SDCCH   SDCCHAC   TN   CBCH     HSN   HOP  DCHNO") == 0)
                               w = w + 1;
                       }
                       temp_file.WriteLine("GN");
                       temp_file.Close();
                       if (w == 0)
                       {
                           MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                           File.Delete(@"D:\\DataBase_BSC\\rlcfp.txt");
                       }
                   }
                  // else
                     //  MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
///////////////////////////////////////////////////////////////
               //////////////////// RLCPP -------------------------
               if (string.Compare(comboBox5.Text,"RLCPP")==0)
               {
                   if (textBox15.Text != "")
                   {
                       string[] temp = File.ReadAllLines(@textBox15.Text);
                       StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlcpp.txt");
                       for (int i = 0; i < temp.Length; i++)
                       {
                           if (temp[i].StartsWith("END")) temp[i] = ""; 
                           temp_file.WriteLine(temp[i]);
                           if (string.Compare(temp[i], "CELL      TYPE BSPWRB BSPWRT MSTXPWR SCTYPE") == 0)
                               w = w + 1;
                       }
                       temp_file.WriteLine("GN");
                       temp_file.Close();
                       if (w == 0)
                       {
                           MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                           File.Delete(@"D:\\DataBase_BSC\\rlcpp.txt");
                       }
                   }
                  // else
                    //   MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
///////////////////////////////////////////////////////////////
               //////////////////// RLBDP -------------------------
               if (string.Compare(comboBox5.Text,"RLBDP")==0)
               {
                   if (textBox15.Text != "")
                   {
                       string[] temp = File.ReadAllLines(@textBox15.Text);
                       StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlbdp.txt");
                       for (int i = 0; i < temp.Length; i++)
                       {
                           if (temp[i].StartsWith("END")) temp[i] = ""; 
                           temp_file.WriteLine(temp[i]);
                           if (string.Compare(temp[i], "CHGR   NUMREQBPC  NUMREQEGPRSBPC  NUMREQCS3CS4BPC  TN7BCCH  EACPREF") == 0)
                               w = w + 1;
                       }
                       temp_file.WriteLine("GN");
                       temp_file.Close();
                       if (w == 0)
                       {
                           MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                           File.Delete(@"D:\\DataBase_BSC\\rlbdp.txt");
                       }
                   }
                   //else
                     //  MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
///////////////////////////////////////////////////////////////
               //////////////////// RLCHP -------------------------
               if (string.Compare(comboBox5.Text,"RLCHP")==0)
               {
                   if (textBox15.Text != "")
                   {
                       string[] temp = File.ReadAllLines(@textBox15.Text);
                       StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\rlchp.txt");
                       for (int i = 0; i < temp.Length; i++)
                       {
                           if (temp[i].StartsWith("END")) temp[i] = ""; 
                           temp_file.WriteLine(temp[i]);
                           if (string.Compare(temp[i], "CHGR  HSN  HOP  MAIO      BCCD") == 0)
                               w = w + 1;
                       }
                       temp_file.WriteLine("GN");
                       temp_file.Close();
                       if (w == 0)
                       {
                           MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                           File.Delete(@"D:\\DataBase_BSC\\rlchp.txt");
                       }
                   }
                  // else
                      // MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
//////////////////////////////////////////////////////////////////////////////
               comboBox5.SelectedItem = "Non";
               
            if(w!=0 && textBox15.Text!="")   
            MessageBox.Show("فایلها بار گذاری شد");
            else
            MessageBox.Show("!!!! فایلها بار گذاری نشد ");
            textBox15.Text = "";
        }

     /*   private void button12_Click(object sender, EventArgs e)
        {
            int w = 0;
            string bs="";
            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\84");
            Create_Folder(@"D:\DataBase_BSC\86");
            Create_Folder(@"D:\DataBase_BSC\94");
            Create_Folder(@"D:\DataBase_BSC\eliminate");
            if (comboBox6.SelectedItem.ToString() == "B176E") bs = "B176E";
            if (comboBox6.SelectedItem.ToString() == "B177E") bs = "B177E";
            if (comboBox6.SelectedItem.ToString() == "B178E") bs = "B178E";
            if (comboBox6.SelectedItem.ToString() == "B179E") bs = "B179E";


///////////////////////////////////////////////////////////////
            //////////////////// RXMOP -------------------------
            if (string.Compare(comboBox8.Text,"RXMOP")==0)
            {
                if (textBox16.Text != "")
                {
                    string[] temp = File.ReadAllLines(@textBox16.Text);
                   
                    StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\"+bs+"_rxmop.txt");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp_file.WriteLine(temp[i]);
                        if (string.Compare(temp[i], "MO                RSITE                         AHOP  COMB  FHOP  MODEL") == 0)
                            w = w + 1;
                    }
                    temp_file.WriteLine("MO");
                    temp_file.Close();
                    if (w == 0)
                    {
                        MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                        File.Delete(@"D:\\DataBase_BSC\\" + bs + "_rxmop.txt");
                    }
                }
              //  else
                 //   MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
///////////////////////////////////////////////////////////////
            //////////////////// RXTCP -------------------------
            if (string.Compare(comboBox8.Text,"RXTCP")==0)
            {
                if (textBox16.Text != "")
                {
                    string[] temp = File.ReadAllLines(@textBox16.Text);
                    StreamWriter temp_file = new StreamWriter("D:\\DataBase_BSC\\" + bs + "_rxtcp.txt");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp_file.WriteLine(temp[i]);
                        if (string.Compare(temp[i], "MO               CELL                CHGR") == 0)
                            w = w + 1;
                    }
                    temp_file.WriteLine("MO");
                    temp_file.Close();
                    if (w == 0)
                    {
                        MessageBox.Show("فایل انتخاب شده فایل مفروض نمی باشد");
                        File.Delete(@"D:\\DataBase_BSC\\" + bs + "_rxtcp.txt");
                    }
                }
               // else
                   // MessageBox.Show("Don't Select File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
///////////////////////////////////////////////////
            if (w != 0 && textBox16.Text != "")
                MessageBox.Show("فایلها بار گذاری شد");
            else
                MessageBox.Show("!!!! فایلها بار گذاری نشد ");
            textBox15.Text = "";
            
            comboBox6.SelectedItem = "Non";
            comboBox8.SelectedItem = "Non";
            textBox16.Text = "";
        }
        */
        private void button13_Click(object sender, EventArgs e)
        {
            string temp176 = "", temp177 = "", temp178 = "", temp179 = "", temp180 = "", temp181 = "";
            dataGridView6.Rows.Clear();
            if (File.Exists(@"D:\\DataBase_BSC\\rldep.txt"))
                dataGridView6.Rows.Add("rldep", "OK", "OK", "OK", "OK","OK","OK");
            else
                dataGridView6.Rows.Add("rldep", "--", "--", "--", "--", "--", "--");


            if (File.Exists(@"D:\\DataBase_BSC\\rlnrp.txt"))
                dataGridView6.Rows.Add("rlnrp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlnrp", "--", "--", "--", "--", "--", "--");


            if (File.Exists(@"D:\\DataBase_BSC\\rlmfp.txt"))
                dataGridView6.Rows.Add("rlmfp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlmfp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\rlcfp.txt"))
                dataGridView6.Rows.Add("rlcfp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlcfp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\rlbdp.txt"))
                dataGridView6.Rows.Add("rlbdp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlbdp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\rlcpp.txt"))
                dataGridView6.Rows.Add("rlcpp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlcpp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\rlchp.txt"))
                dataGridView6.Rows.Add("rlchp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlchp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\rlcfp.txt"))
                dataGridView6.Rows.Add("rlcfp", "OK", "OK", "OK", "OK", "OK", "OK");
            else
                dataGridView6.Rows.Add("rlcfp", "--", "--", "--", "--", "--", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b176e.txt"))
                temp176="OK";
            else  temp176="--";
            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b177e.txt"))
                temp177 = "OK";
            else temp177 = "--";
            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b178e.txt"))
                temp178 = "OK";
            else temp178 = "--";
            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b179e.txt"))
                temp179 = "OK";
            else temp180 = "--";
            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b180e.txt"))
                temp180 = "OK";
            else temp180 = "--";
            if (File.Exists(@"D:\\DataBase_BSC\\bsc border\\b181e.txt"))
                temp181 = "OK";
            else temp181 = "--";

            dataGridView6.Rows.Add("bsc border", temp176, temp177, temp178, temp179, temp180, temp181);
            


          /*  if (File.Exists(@"D:\\DataBase_BSC\\B176E_rxtcp.txt"))
                dataGridView6.Rows.Add("rxtcp","OK");
            else 
                dataGridView6.Rows.Add("rxtcp", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\B177E_rxtcp.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count-2].Cells[2].Value = "OK";
           
            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[2].Value = "--";

            if (File.Exists(@"D:\\DataBase_BSC\\B178E_rxtcp.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[3].Value = "OK";

            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[3].Value = "--";


            if (File.Exists(@"D:\\DataBase_BSC\\B179E_rxtcp.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[4].Value = "OK";

            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[4].Value = "--";

            if (File.Exists(@"D:\\DataBase_BSC\\B176E_rxmop.txt"))
                dataGridView6.Rows.Add("rxmop", "OK");
            else
                dataGridView6.Rows.Add("rxmop", "--");

            if (File.Exists(@"D:\\DataBase_BSC\\B177E_rxmop.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[2].Value = "OK";

            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[2].Value = "--";

            if (File.Exists(@"D:\\DataBase_BSC\\B178E_rxmop.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[3].Value = "OK";

            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[3].Value = "--";


            if (File.Exists(@"D:\\DataBase_BSC\\B179E_rxmop.txt"))
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[4].Value = "OK";

            else
                dataGridView6.Rows[dataGridView6.Rows.Count - 2].Cells[4].Value = "--";*/
           
        }
//----------------------------------- BSC Border --------------------------------
        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.CheckFileExists = true;
            myOpenFileDialog.DefaultExt = "txt";
            myOpenFileDialog.InitialDirectory = @"d:\";
            myOpenFileDialog.Multiselect = false;
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox17.Text = myOpenFileDialog.FileName;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string bs = "";
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            if (comboBox7.SelectedItem.ToString() == "B176E")
            {
                bs = "B176E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b176e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }
            if (comboBox7.SelectedItem.ToString() == "B177E")
            {
                bs = "B177E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b177e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }
            if (comboBox7.SelectedItem.ToString() == "B178E")
            {
                bs = "B178E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b178e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }
            if (comboBox7.SelectedItem.ToString() == "B179E")
            {
                bs = "B179E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b179e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }
            if (comboBox7.SelectedItem.ToString() == "B180E")
            {
                bs = "B180E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b180e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }
            if (comboBox7.SelectedItem.ToString() == "B181E")
            {
                bs = "B181E";
                StreamWriter bsc_border = new StreamWriter("D:\\DataBase_BSC\\bsc border\\b181e.txt");
                string[] temp = File.ReadAllLines(@textBox17.Text);
                for (int i = 0; i < temp.Length; i++)
                {
                    bsc_border.WriteLine(temp[i]);
                }
                bsc_border.WriteLine("GN");
                bsc_border.Close();
            }

            MessageBox.Show("فایل بارگذاری شد");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bound = "1800";
            string gn = textBox18.Text;
            string bsc = "";
            string gn0 = gn;
            gn = gn.ToUpper();

            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\1800");
            Create_Folder(@"D:\DataBase_BSC\86\1800");
            Create_Folder(@"D:\DataBase_BSC\94\1800");
            Create_Folder(@"D:\DataBase_BSC\eliminate");

            StreamWriter sw_1800 = new StreamWriter("D:\\DataBase_BSC\\84\\1800\\" + gn0 + "_84" + ".txt");
            if ((checkBox22.Checked == true))
            {
                sector4 = "D";
                gn = gn0 + sector4;
                detail.propertic(gn, gn0, bsc, bound);

                MessageBox.Show(detail.DCHNO);
                if ((detail.CGI == "") || (detail.BSIC == "") || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")
                    MessageBox.Show("The Data System is Blank");
                sw_1800.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE= GSM1800;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",CGI="+detail.CGI+",BSIC="+detail.BSIC+",BCCHNO="+detail.BCCH+",AGBLK=1;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                //sw_1800.WriteLine("RLDEP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLDGI:CELL=" + gn + ",CHGR=1;");
                sw_1800.WriteLine("RLCFI:CELL=" + gn + ",CHGR=1,DCHNO="+detail.DCHNO+";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw_1800.WriteLine("RLIMI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB="+detail.BSPWR+";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=30,BSPWRT=" + detail.BSPWR + ";");
                //sw_1800.WriteLine("RLCPP:CELL=" + gn + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSPWR=" + BSTXPWR + ",BSRXMIN= 102,BSRXSUFF=110;");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                //sw_1800.WriteLine("RLLOP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",IHO=On,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                //sw_1800.WriteLine("RLIHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                //sw_1800.WriteLine("RLLFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                //sw_1800.WriteLine("RLLDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                //sw_1800.WriteLine("RLLUP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88,SSLENUL=3;");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5,LCOMPUL=50,REGINTUL=5,DTXFUL=5,QDESUL=20,QCOMPUL=60;");
                sw_1800.WriteLine("RLPCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLPCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");
                //sw_1800.WriteLine("RLLPP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF,SSDESDL=82,SSLENDL=3,QLENDL=5,BSPWRMINP=30;");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50,REGINTDL=5,QDESDL=20,QCOMPDL=60;");
                sw_1800.WriteLine("RLBCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLBCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLHC:CELL=" + gn + ",LAYER=4,LAYERTHR=85,LAYERHYST=5,PSSTEMP=25,PTIMTEMP=20,FASTMSREG=ON;");
                //sw_1800.WriteLine("RLLHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if(detail.SDCCH_CH1!="")
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
                sw_1800.WriteLine("RLACI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 0,NUMREQBPC="+detail.NUMREQBP_CH0+";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                if (detail.SDCCH_CH1 != "")
                sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 1,NUMREQBPC="+detail.NUMREQBP_CH1+";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=30,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=16,NECI=1,MBCR=2;");
                sw_1800.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                if (detail.SDCCH_CH1 != "")
                {
                    sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH="+detail.SDCCH_CH1+",TN=1&&7;");
                    sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP="+detail.HOP_CH1+",HSN="+detail.HSN_CH1+",MAIO="+detail.MAIO_CH1+";");
                }
                sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" + detail.SDCCH_CH0 + ",TN=1&&7,CBCH=NO;");
                sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0 + ",HSN=" + detail.HSN_CH0 + ",MAIO=" + detail.MAIO_CH0 + ";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");
                sw_1800.WriteLine("RLSLI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLSLP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLVLE:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if (detail.SDCCH_CH1 != "")
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
                sw_1800.WriteLine(" ");
            }

            ///                 1800   84  sector E
            if ((checkBox23.Checked == true))
            {
                sector5 = "E";
                gn = "";
                gn = gn0 + sector5;
                detail.propertic(gn, gn0, bsc, bound);

                MessageBox.Show(detail.DCHNO);
                if ((detail.CGI == "") || (detail.BSIC == "") || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")
                    MessageBox.Show("The Data System is Blank");
                sw_1800.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE= GSM1800;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ",AGBLK=1;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                //sw_1800.WriteLine("RLDEP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLDGI:CELL=" + gn + ",CHGR=1;");
                sw_1800.WriteLine("RLCFI:CELL=" + gn + ",CHGR=1,DCHNO=" + detail.DCHNO + ";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw_1800.WriteLine("RLIMI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB=" + detail.BSPWR + ";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=30,BSPWRT=" + detail.BSPWR + ";");
                //sw_1800.WriteLine("RLCPP:CELL=" + gn + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSPWR=" + BSTXPWR + ",BSRXMIN= 102,BSRXSUFF=110;");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                //sw_1800.WriteLine("RLLOP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",IHO=On,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                //sw_1800.WriteLine("RLIHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                //sw_1800.WriteLine("RLLFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                //sw_1800.WriteLine("RLLDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                //sw_1800.WriteLine("RLLUP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88,SSLENUL=3;");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5,LCOMPUL=50,REGINTUL=5,DTXFUL=5,QDESUL=20,QCOMPUL=60;");
                sw_1800.WriteLine("RLPCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLPCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");
                //sw_1800.WriteLine("RLLPP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF,SSDESDL=82,SSLENDL=3,QLENDL=5,BSPWRMINP=30;");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50,REGINTDL=5,QDESDL=20,QCOMPDL=60;");
                sw_1800.WriteLine("RLBCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLBCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLHC:CELL=" + gn + ",LAYER=4,LAYERTHR=85,LAYERHYST=5,PSSTEMP=25,PTIMTEMP=20,FASTMSREG=ON;");
                //sw_1800.WriteLine("RLLHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
                sw_1800.WriteLine("RLACI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 0,NUMREQBPC=" + detail.NUMREQBP_CH0 + ";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 1,NUMREQBPC=" + detail.NUMREQBP_CH1 + ";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=30,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=16,NECI=1,MBCR=2;");
                sw_1800.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                if (detail.SDCCH_CH1 != "")
                {
                    sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH=" + detail.SDCCH_CH1 + ",TN=1&&7;");
                    sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP=" + detail.HOP_CH1 + ",HSN=" + detail.HSN_CH1 + ",MAIO=" + detail.MAIO_CH1 + ";");
                }
                sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" + detail.SDCCH_CH0 + ",TN=1&&7,CBCH=NO;");
                sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0 + ",HSN=" + detail.HSN_CH0 + ",MAIO=" + detail.MAIO_CH0 + ";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");
                sw_1800.WriteLine("RLSLI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLSLP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLVLE:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
                sw_1800.WriteLine(" ");
            }


            //////// 1800  84 sector F
            if ((checkBox24.Checked == true))
            {
                sector6 = "F";
                gn = "";
                gn = gn0 + sector6;
                detail.propertic(gn, gn0, bsc, bound);

                MessageBox.Show(detail.DCHNO);
                if ((detail.CGI == "") || (detail.BSIC == "") || detail.BCCH == "" || detail.DCHNO == "" || detail.BSPWR == "" || detail.HOP == "" || detail.HSN == "")
                    MessageBox.Show("The Data System is Blank");
                sw_1800.WriteLine("RLDEI:CELL=" + gn + ",CSYSTYPE= GSM1800;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",CGI=" + detail.CGI + ",BSIC=" + detail.BSIC + ",BCCHNO=" + detail.BCCH + ",AGBLK=1;");
                sw_1800.WriteLine("RLDEC:CELL=" + gn + ",MFRMS=6,FNOFFSET=0,BCCHTYPE=NCOMB;");
                //sw_1800.WriteLine("RLDEP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLDGI:CELL=" + gn + ",CHGR=1;");
                sw_1800.WriteLine("RLCFI:CELL=" + gn + ",CHGR=1,DCHNO=" + detail.DCHNO + ";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIMC:CELL=" + gn + ",INTAVE=6,LIMIT1=2,LIMIT2=6,LIMIT3=12,LIMIT4=22;");
                sw_1800.WriteLine("RLIMI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",BSPWRB=" + detail.BSPWR + ";");
                sw_1800.WriteLine("RLCPC:CELL=" + gn + ",MSTXPWR=30,BSPWRT=" + detail.BSPWR + ";");
                //sw_1800.WriteLine("RLCPP:CELL=" + gn + ";");
                int int_power = 0;
                int_power = int.Parse(detail.BSPWR);
                int_power = int_power - 5;
                string BSTXPWR = int_power.ToString();
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSTXPWR=" + BSTXPWR + ";");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",BSPWR=" + BSTXPWR + ",BSRXMIN= 102,BSRXSUFF=110;");
                sw_1800.WriteLine("RLLOC:CELL=" + gn + ",MSRXMIN=102,MSRXSUFF=0,SCHO=OFF,AW=OFF,MISSNM=3;");
                //sw_1800.WriteLine("RLLOP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",IHO=On,MAXIHO=3,TMAXIHO=6,QOFFSETULN=1;");
                sw_1800.WriteLine("RLIHC:CELL=" + gn + ",QOFFSETDLN=1,TIHO=5,SSOFFSETULP=0,SSOFFSETDLP=0;");
                //sw_1800.WriteLine("RLIHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLFC:CELL=" + gn + ",QEVALSD=6,QEVALSI=6,SSEVALSD=6,SSEVALSI=6;");
                //sw_1800.WriteLine("RLLFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLDC:CELL=" + gn + ",MAXTA=63,RLINKUP=16;");
                //sw_1800.WriteLine("RLLDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",TALIM=62,CELLQ=LOW;");
                sw_1800.WriteLine("RLLUC:CELL=" + gn + ",QLIMUL=55,QLIMDL=55;");
                //sw_1800.WriteLine("RLLUP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",SSDESUL=88,SSLENUL=3;");
                sw_1800.WriteLine("RLPCC:CELL=" + gn + ",QLENUL=5,LCOMPUL=50,REGINTUL=5,DTXFUL=5,QDESUL=20,QCOMPUL=60;");
                sw_1800.WriteLine("RLPCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLPCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLPC:CELL=" + gn + ",PTIMHF=5,PTIMBQ=10,PTIMTA=5,PSSHF=63,PSSBQ=10,PSSTA=63;");
                //sw_1800.WriteLine("RLLPP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",SDCCHREG=OFF,SSDESDL=82,SSLENDL=3,QLENDL=5,BSPWRMINP=30;");
                sw_1800.WriteLine("RLBCC:CELL=" + gn + ",LCOMPDL=50,REGINTDL=5,QDESDL=20,QCOMPDL=60;");
                sw_1800.WriteLine("RLBCI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLBCP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLLHC:CELL=" + gn + ",LAYER=4,LAYERTHR=85,LAYERHYST=5,PSSTEMP=25,PTIMTEMP=20,FASTMSREG=ON;");
                //sw_1800.WriteLine("RLLHP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",CB=NO,ACC=CLEAR,MAXRET=4,TX=32,ATT=YES;");
                sw_1800.WriteLine("RLSBC:CELL=" + gn + ",T3212=40,CBQ=HIGH,CRO=0,TO=0,PT=0,ECSC=YES;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",CLSLEVEL=20,CLSACC=40;");
                sw_1800.WriteLine("RLLCC:CELL=" + gn + ",HOCLSACC=OFF,RHYST=75,CLSRAMP=8;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
                sw_1800.WriteLine("RLACI:CELL=" + gn + ";");
                sw_1800.WriteLine("RLHPC:CELL=" + gn + ",CHAP=1;");
                sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 0,NUMREQBPC=" + detail.NUMREQBP_CH0 + ";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLBDC:CELL=" + gn + ",CHGR= 1,NUMREQBPC=" + detail.NUMREQBP_CH1 + ";");
                //sw_1800.WriteLine("RLBDP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSSC:CELL=" + gn + ",ACCMIN=102,CCHPWR=30,CRH=6,DTXU=1,NCCPERM=0&&7,RLINKT=16,NECI=1,MBCR=2;");
                sw_1800.WriteLine("RLCXC:CELL=" + gn + ",DTXD=ON;");
                if (detail.SDCCH_CH1 != "")
                {
                    sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=1,SDCCH=" + detail.SDCCH_CH1 + ",TN=1&&7;");
                    sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=1,HOP=" + detail.HOP_CH1 + ",HSN=" + detail.HSN_CH1 + ",MAIO=" + detail.MAIO_CH1 + ";");
                }
                sw_1800.WriteLine("RLCCC:CELL=" + gn + ",CHGR=0,SDCCH=" + detail.SDCCH_CH0 + ",TN=1&&7,CBCH=NO;");
                sw_1800.WriteLine("RLCHC:CELL=" + gn + ",CHGR=0,HOP=" + detail.HOP_CH0 + ",HSN=" + detail.HSN_CH0 + ",MAIO=" + detail.MAIO_CH0 + ";");
                //sw_1800.WriteLine("RLCFP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=1,ACL=A1,CHTYPE=BCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=0,ACL=A2,CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLSLC:CELL=" + gn + ",LVA=6,ACL=A3,CHTYPE=TCH,CHRATE=FR,SPV=1;");
                sw_1800.WriteLine("RLSLI:CELL=" + gn + ";");
                //sw_1800.WriteLine("RLSLP:CELL=" + gn + ";");
                sw_1800.WriteLine("RLVLE:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLE:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CELL=" + gn + ",CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=TCH;");
                sw_1800.WriteLine("RLVLI:CHTYPE=SDCCH;");
                sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=0,INCL,SLEVEL=0;");
                if (detail.SDCCH_CH1 != "")
                    sw_1800.WriteLine("RLACC:CELL=" + gn + ",STIME=20,CHGR=1,INCL,SLEVEL=0;");
            }

            sw_1800.Close();
            MessageBox.Show("The 84 file for CodeSite = " + gn0 + " is Created in Folder as:     D:\\DataBase_BSC\\84");
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox25.Checked == false && checkBox26.Checked == false && checkBox27.Checked == false)
                MessageBox.Show(" No Sector Selected");
            if (textBox25.Text == "GN0")
                MessageBox.Show(" The Code Side is not Completed");
            bound = "1800";
            string gn = textBox25.Text;
            string gn0 = gn;
            string bsc = "";
            gn = gn.ToUpper();

            Create_Folder(@"D:\DataBase_BSC");
            Create_Folder(@"D:\DataBase_BSC\bsc border");
            Create_Folder(@"D:\DataBase_BSC\84\1800");
            Create_Folder(@"D:\DataBase_BSC\86\1800");
            Create_Folder(@"D:\DataBase_BSC\94\1800");
            Create_Folder(@"D:\DataBase_BSC\eliminate");

            StreamWriter sw_94_1800 = new StreamWriter("d:\\DataBase_BSC\\94\\1800\\" + gn + "_94" + ".txt");

            // if (radioButton6.Checked) { bsc = "b176e"; }
            // if (radioButton5.Checked) { bsc = "b177e"; }
            // if (radioButton4.Checked) { bsc = "b178e"; }
            // if (radioButton1.Checked) { bsc = "b179e"; }

            detail.propertic(gn + "D", gn0, bsc, bound);
            string TG = textBox21.Text;
            string SOFWARE = "";
            int s = 2 * int.Parse(TG);
            string RXODPI = s.ToString();
            string DCP1 = "", DCP2 = "";
            SOFWARE = comboBox8.Text;
            if (SOFWARE == "Non")
            {
                SOFWARE = textBox19.Text;
                if (SOFWARE == "") MessageBox.Show("The SoftWare Ver. Was Not Identified");
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            sw_94_1800.WriteLine("DTIDP:DIP=" + TG + "RBL2;");
            sw_94_1800.WriteLine("DTBLI:DIP=" + TG + "RBL2;");
            sw_94_1800.WriteLine("DTIDC:DIP=" + TG + "RBL2,CRC=0;");
            sw_94_1800.WriteLine("DTFSC:DIP=" + TG + "RBL2,FAULT=1&2&3&4,ACL=A3;");
            sw_94_1800.WriteLine("DTQSC:DIP=" + TG + "RBL2,SES,SESL=7,ACL1=A2,RSESL=0,SESL2=6,ACL2=A3;");
            sw_94_1800.WriteLine("DTQSC:DIP=" + TG + "RBL2,ES,ESL=120,ACL1=A2,RESL=0,ESL2=100,ACL2=A3;");
            sw_94_1800.WriteLine("DTQSC:DIP=" + TG + "RBL2,SF,SFL=5,TI=24,ACL=A3;");
            sw_94_1800.WriteLine("DTQSI:DIP=" + TG + "RBL2,SES,ES,SF;");
            sw_94_1800.WriteLine("DTFSI:DIP=" + TG + "RBL2,FAULT=1&2&3&4;");
            sw_94_1800.WriteLine("DTFSP:DIP=" + TG + "RBL2;");
            sw_94_1800.WriteLine("DTQSP:DIP=" + TG + "RBL2;");


            sw_94_1800.WriteLine("RXMOI:MO=RXOTG-" + TG + ",COMB=HYB,RSITE=" + textBox20.Text + ",SWVER=" + SOFWARE + ";");
            sw_94_1800.WriteLine("RXMOC:MO=RXOTG-" + TG + ",FHOP=SY,CONFMD=CMD,CONFACT=" + comboBox9.Text + ",TRACO=POOL;");
            sw_94_1800.WriteLine("RXMOP:MO=RXOTG-" + TG + ";");

            sw_94_1800.WriteLine("RXMOI:MO=RXOCF-" + TG + ",TEI=62,SIG=CONC;");
            sw_94_1800.WriteLine("RXMOP:MO=RXOCF-" + TG + ";");

            sw_94_1800.WriteLine("RXOI:MO=RXOCON-" + TG + ", DCP=64&&87;");

            sw_94_1800.WriteLine("RXMOI:MO=RXOTF-" + TG + ",TFMODE=SA;");
            sw_94_1800.WriteLine("RXMOP:MO=RXOTF-" + TG + ";");

            sw_94_1800.WriteLine("RXMOI:MO=RXOIS-" + TG + ";");
            sw_94_1800.WriteLine("RXMOP:MO=RXOIS-" + TG + ";");

            sw_94_1800.WriteLine("RXMOI:MO=RXODP-" + TG + "-0,DEV=RXODPI-" + RXODPI + ";");
            sw_94_1800.WriteLine("RXMOP:MO=RXODP-" + TG + "-0;");

            //sw_94_1800.WriteLine("RLDEP:CELL=GN0268D;");

            if ((checkBox27.Checked == true))
            {
                sector1 = "D";
                string gnD = gn + sector1;
                detail.propertic(gnD, gn0, bsc, bound);

                if (textBox24.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_D = int.Parse(textBox24.Text);
                for (int r = 0; r < Number_of_TRX_D; r++)
                {
                    if (r == 0) { DCP1 = "128"; DCP2 = "129&130"; }
                    if (r == 1) { DCP1 = "131"; DCP2 = "132&133"; }
                    if (r == 2) { DCP1 = "134"; DCP2 = "135&136"; }
                    if (r == 3) { DCP1 = "137"; DCP2 = "138&139"; }

                    sw_94_1800.WriteLine("RXMOI:MO=RXOTRX-" + TG + "- "+ r + ",TEI= "+r+",DCP1= " + DCP1 + ",DCP2= " + DCP2 + ",SIG=CONC;");

                    ////////////////
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL=" + gn0 + "D;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM1800 ,MPWR=47;");
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL=" + gn0 + "D;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM1800,RXD=AB;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                }
            }
                    

                    //sw_94_1800.WriteLine("RLDEP:CELL=GN0268E;");
            if ((checkBox26.Checked == true))
            {
                sector1 = "E";
                string gnE = gn + sector1;
                detail.propertic(gnE, gn0, bsc, bound);

                if (textBox23.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_E = int.Parse(textBox23.Text);
                for (int r = 4; r < Number_of_TRX_E+4; r++)
                {
                    if (r == 4) { DCP1 = "140"; DCP2 = "141& 142"; }
                    if (r == 5) { DCP1 = "143"; DCP2 = "144& 145"; }
                    if (r == 6) { DCP1 = "160"; DCP2 = "161& 162"; }
                    if (r == 7) { DCP1 = "163"; DCP2 = "164& 165"; }


                    sw_94_1800.WriteLine("RXMOI:MO=RXOTRX-" + TG + "-" + r + ",TEI= " + r + ",DCP1="+DCP1+",DCP2="+DCP2+",SIG=CONC;");
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL=" + gn0 + "E;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM1800 ,MPWR=47;");
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL=" + gn0 + "E;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM1800,RXD=AB;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");

                }
            }

            if ((checkBox25.Checked == true))
            {
                sector1 = "F";
                string gnF = gn + sector1;
                detail.propertic(gnF, gn0, bsc, bound);

                if (textBox22.Text == "") MessageBox.Show(" Number Of TRX is not define");
                Number_of_TRX_F = int.Parse(textBox22.Text);
                for (int r = 8; r < Number_of_TRX_F + 8; r++)
                {
                    if (r == 8) { DCP1 = "166"; DCP2 = "167& 168"; }
                    if (r == 9) { DCP1 = "169"; DCP2 = "170& 171"; }
                    if (r == 10) { DCP1 = "172"; DCP2 = "173& 174"; }
                    if (r == 11) { DCP1 = "175"; DCP2 = "176& 177"; }


                    sw_94_1800.WriteLine("RXMOI:MO=RXOTRX-" + TG + "-" + r + ",TEI= 8,DCP1="+DCP2+",DCP2="+DCP2+",SIG=CONC;");
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTRX-" + TG + "-" + r + ",CELL="+gn0+"F;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTRX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTX-" + TG + "-" + r + ",BAND=GSM1800 ,MPWR=47;");
                    sw_94_1800.WriteLine("RXMOC:MO=RXOTX-" + TG + "-" + r + ",CELL="+gn0+"F;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXORX-" + TG + "-" + r + ",BAND=GSM1800,RXD=AB;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXORX-" + TG + "-" + r + ";");
                    sw_94_1800.WriteLine("RXMOI:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");
                    sw_94_1800.WriteLine("RXMOP:MO=RXOTS-" + TG + "-" + r + "-0&&-7;");

                }
            }

                    sw_94_1800.WriteLine("RXAPI:MO=RXOTG-" + TG + ",DEV=RBLT2-"+textBox26.Text+"&&-"+textBox27.Text+",DCP=1&&31;");
                    sw_94_1800.WriteLine("RXAPP:MO=RXOTG-" + TG + ";");


                    sw_94_1800.WriteLine("DTDII:DIP=ODPI " + RXODPI + ",DEV=RXODPI-" + RXODPI + ";");
                    sw_94_1800.WriteLine("DTIDP:DIP=ODPI " + RXODPI + ";");
                    sw_94_1800.WriteLine("DTIDC:DIP=ODPI " + RXODPI + ",CRC=0;");
                    sw_94_1800.WriteLine("DTFSC:DIP=ODPI " + RXODPI + ",FAULT=1&2&3&4&9,ACL=A3;");
                    sw_94_1800.WriteLine("DTQSC:DIP=ODPI " + RXODPI + ",BFF,BFFL1=100,ACL1=A3,BFFL2=800,ACL2=A2;");
                    sw_94_1800.WriteLine("DTQSC:DIP=ODPI " + RXODPI + ",SF,SFL=5,TI=24,ACL=A3;");
                    sw_94_1800.WriteLine("DTQSC:DIP=ODPI " + RXODPI + ",DF,DFL=5,TI=24,ACL=A3;");
                    sw_94_1800.WriteLine("DTQSI:DIP=ODPI " + RXODPI + ",BFF,LL,LH,SF,DF;");

                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "D,CHGR=0;");
                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "E,CHGR=0;");
                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "F,CHGR=0;");
                    sw_94_1800.WriteLine("RXTCP:MO=RXOTG-" + TG + ";");

                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "D,CHGR=1;");
                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "E,CHGR=1;");
                    sw_94_1800.WriteLine("RXTCI:MO=RXOTG-" + TG + ",CELL=" + gn0 + "F,CHGR=1;");
                    sw_94_1800.WriteLine("RXTCP:MO=RXOTG-" + TG + ";");

                    sw_94_1800.WriteLine("DTSTP:DIP=" + TG + "RBL2;");
                    sw_94_1800.WriteLine("DTBLE:DIP=" + TG + "RBL2;");

                    sw_94_1800.WriteLine("DTSTP:DIP=ODPI " + RXODPI + ";");
                    sw_94_1800.WriteLine("DTBLE:DIP=ODPI " + RXODPI + ";");

                    sw_94_1800.WriteLine("STDEP:RBLT2-"+textBox26.Text+"&&-"+textBox27.Text+";");
                    sw_94_1800.WriteLine("EXDAI:RBLT2-"+textBox26.Text+"&&-"+textBox27.Text+";");
                    sw_94_1800.WriteLine("BLODE:RBLT2-"+textBox26.Text+"&&-"+textBox27.Text+";");


                    sw_94_1800.WriteLine("RXESI:MO=RXOTG-" + TG + ",SUBORD;");
                    sw_94_1800.WriteLine("RXBLE:MO=RXOTG-" + TG + ",SUBORD;");

                    sw_94_1800.WriteLine("RLSTC:CELL="+gn0+"D,STATE=ACTIVE;");
                    sw_94_1800.WriteLine("RLSTP:CELL="+gn0+"D;");
                    sw_94_1800.WriteLine("RLCRP:CELL="+gn0+"D;");
                    sw_94_1800.WriteLine("RLSTC:CELL="+gn0+"E,STATE=ACTIVE;");
                    sw_94_1800.WriteLine("RLSTP:CELL="+gn0+"E;");
                    sw_94_1800.WriteLine("RLCRP:CELL="+gn0+"E;");
                    sw_94_1800.WriteLine("RLSTC:CELL="+gn0+"F,STATE=ACTIVE;");
                    sw_94_1800.WriteLine("RLSTP:CELL="+gn0+"F;");
                    sw_94_1800.WriteLine("RLCRP:CELL="+gn0+"F;");

                    sw_94_1800.WriteLine("RXCDP:MO=RXOTG-" + TG + ";");



                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

             sw_94_1800.Close();
            MessageBox.Show("The 94 file for CodeSite = " + gn0 + " is Created in folder as:   D:\\DataBase_BSC\\94 ");

                }

                //-------------------------------------------------------------------------------      
            }

            //---------------------------
        }

        
        
                    
    
               
   
            
        
    
