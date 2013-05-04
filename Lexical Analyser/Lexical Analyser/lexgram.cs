using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyser
{
    class lexgram
    {
        private static short lof_ident = 10;
        bool check()
        {
            return true;
        }

        /***********************/

        void s_input()
        {
            s_main(); /* | */s_stmt();
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
