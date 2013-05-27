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
        public string[] bosluk;
        public bool acceptStatement = false;

        public string outputKod = "";

        public void trimmer()
        {
            kod = kod.Trim();
            kod = kod.Replace("(", " ");
            kod = kod.Replace(")", " ");
            kod = kod.Replace("=","= ");
            while(kod.Contains("  "))kod = kod.Replace("  "," ");
            while(kod.Contains("\t"))kod = kod.Replace("\t", "");
            while(kod.Contains("\n "))kod = kod.Replace("\n ","\n");
            while (kod.Contains(" \n")) kod = kod.Replace(" \n", "\n");
            while (kod.Contains("\n\n")) kod = kod.Replace("\n\n", "\n");
            kod = kod.Replace("\n"," ");
            kod = kod.ToLower();
            kod = kod.Trim();
            bosluk = kod.Split(' ');
        }

        public string decide(string abbas)
        {
            Match value = Regex.Match(abbas, @"^(\d)(\d*)$");
            Match variable = Regex.Match(abbas, @"^(\D+)(\d*)(\w*)$");
            Match esitlik = Regex.Match(abbas, @"^((<)|(>)|(:))((>)(<)(=))$");


            if (esitlik.Success)
            {
                return "variable";
            }
            else if (value.Success)
            {
                return "value";
            }
            else if (variable.Success)
            {
                return "esitlik";
            }
            else
            {
                return "olmadı";
            }
        }


        public void check(int i)
        {
            if (i < bosluk.Length)
            {
                switch (bosluk[i])
                {
                    case "program":
                        outputKod += bosluk[i];
                        break;
                    case "while":
                        outputKod += bosluk[i];
                        break;
                    case "begin":
                        outputKod += bosluk[i];
                        break;
                    case "end":
                        outputKod += bosluk[i];
                        break;
                    case "if":
                        outputKod += bosluk[i];
                        break;
                    case "then":
                        outputKod += bosluk[i];
                        break;
                    case "else":
                        outputKod += bosluk[i];
                        break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;

                    default:
                        outputKod += decide(bosluk[i]);
                        break;
                }
                check(++i);
            }
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

        

        //void s_input(string s)
        //{
        //    if (s.Contains("program"))
        //    {
        //        s_main();
        //    }
        //    else
        //    {
        //        s_stmt();
        //    }
        //}
        //void s_main()
        //{
        //    /* program */
        //    s_identifier(); s_stmt();/* [ */ s_stmt(); /* ] end */
        //}
        //void s_stmt()
        //{
        //    s_assign(); /* | */ s_if_stmt(); /* | */ s_while_stmt();
        //}
        //void s_assign()
        //{
        //    s_identifier(); /* := */ s_expr();
        //}
        //void s_if_stmt()
        //{
        //    /* if( */
        //    s_cond(); /* )then */ s_stmt(); /* [else */ s_stmt(); /* ] */
        //}
        //void s_while_stmt()
        //{
        //    /* while( */
        //    s_cond(); /* ) */ s_block();
        //}
        //void s_cond()
        //{
        //    s_identifier(); /* >,<,>=,<=,<> */ s_identifier();
        //}
        //void s_block()
        //{
        //    /* begin */
        //    s_stmt(); /* end */
        //}
        //void s_expr()
        //{
        //    s_expr(); /* (+ , -  , * ,  / )  */ s_expr();
        //    /* |( */
        //    s_expr(); /* ) */
        //    /* | */
        //    s_identifier();
        //    /* | */
        //    s_int_value();
        //}
        //void s_identifier()
        //{
        //    /* A|…|Z|a|…|z [A|…|Z|a|…|z|0|…|9] */
        //}
        //void s_int_value()
        //{
        //    /* any legal integer number in C# */
        //}

    }
}