using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lexical_Analyser
{
    class lexgram
    {
        public string kod ="";
        public string[] satır;
        public string[][] hece;
        public bool acceptStatement = false;

        public void trimmer()
        {
            kod = kod.Trim();
            kod = kod.Replace("("," ( ");
            kod = kod.Replace(")", " ) ");
            kod = kod.Replace("=","= ");
            while(kod.Contains("  "))kod = kod.Replace("  "," ");
            while(kod.Contains("\t"))kod = kod.Replace("\t", "");
            while(kod.Contains("\n "))kod = kod.Replace("\n ","\n");
            while (kod.Contains(" \n")) kod = kod.Replace(" \n", "\n");
            while (kod.Contains("\n\n")) kod = kod.Replace("\n\n", "\n");
            kod = kod.ToLower();
        }
        public void splitter()
        {
            satır = kod.Split('\n');
            hece = new string[satır.Length][];

            for (int i = 0; i < satır.Length; i++)
            {
                hece[i] = satır[i].Split(' ');
            }
        }

        public string tara()
        {
            for(int i=0; i < hece.Length; i++)
            {
                for (int j = 0; j < hece[i].Length; j++ )
                {
                    return hece[i][j];
                }
            }
            return "";
        }

        public void BeginWhileEndKontrol()
        {
            if (kod.Contains("program"))
            {
                if (kod.Contains("while"))
                {
                    if (kod.Contains("begin"))
                    {
                        if (TextTool.CountStringOccurrences(kod, "end") == 2)
                            acceptStatement = true;
                        else
                            acceptStatement = false;
                    }
                    else
                        acceptStatement = false;
                }
                else
                {
                    if (TextTool.CountStringOccurrences(kod, "end") == 1)
                        acceptStatement = true;
                    else
                        acceptStatement = false;
                }


            }
            else
            {
                if (kod.Contains("while"))
                {
                    if (kod.Contains("begin"))
                    {
                        if (TextTool.CountStringOccurrences(kod, "end") == 1)
                            acceptStatement = true;
                        else
                            acceptStatement = false;
                    }
                    else
                        acceptStatement = false;
                }
                else
                {
                    if (TextTool.CountStringOccurrences(kod, "end") == 0)
                        acceptStatement = true;
                    else
                        acceptStatement = false;
                }
            }
        }

        /***********************/

        void s_input(string s)
        {
            if (s.Contains("program") )
            {
                s_main();
            }
            else
            {
                s_stmt();
            }
        }
        void s_main()
        {
            /* program */ s_identifier(); s_stmt();/* [ */ s_stmt(); /* ] end */
        }
        void s_stmt()
        {
            s_assign(); /* | */ s_if_stmt(); /* | */ s_while_stmt();
        }
        void s_assign()
        {
            s_identifier(); /* := */ s_expr();
        }
        void s_if_stmt()
        {
            /* if( */ s_cond(); /* )then */ s_stmt(); /* [else */ s_stmt(); /* ] */
        }
        void s_while_stmt()
        {
            /* while( */ s_cond(); /* ) */ s_block();
        }
        void s_cond()
        {
            s_identifier(); /* >,<,>=,<=,<> */ s_identifier();
        }
        void s_block()
        {
            /* begin */ s_stmt(); /* end */
        }
        void s_expr()
        {
            s_expr(); /* (+ , -  , * ,  / )  */ s_expr();
            /* |( */ s_expr(); /* ) */
            /* | */ s_identifier();
            /* | */ s_int_value();
        }
        void s_identifier()
        {
            /* A|…|Z|a|…|z [A|…|Z|a|…|z|0|…|9] */
        }
        void s_int_value()
        {
            /* any legal integer number in C# */
        }
    }
}