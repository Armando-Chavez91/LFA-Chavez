using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1_LFA
{
    public class FormatoGramatica
    {
        // SETS
        private static string SETS = @"^(\s*([A-Z])+\s*=\s*((((\'([A-Z]|[a-z]|[0-9]|_)\'\.\.\'([A-Z]|[a-z]|[0-9]|_)\')\+)*(\'([A-z]|[a-z]|[0-9]|_)\'\.+\'([A-z]|[a-z]|[0-9]|_)\')*(\'([A-z]|[a-z]|[0-9]|_)\')+)|(CHR\(+([0-9])+\)+\.\.CHR\(+([0-9])+\)+)+)\s*)";

        // TOKENS
        private static string TOKENS = @"^(\s*TOKEN\s*[0-9]+\s*=\s*(([A-Z]+)|((\'*)([a-z]|[A-Z]|[1-9]|(\<|\>|\=|\+|\-|\*|\(|\)|\{|\}|\[|\]|\.|\,|\:|\;))(\'))+|((\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*([A-Z]|[a-z]|[0-9]|\')*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*([A-Z]|[a-z]|[0-9])*\s*\)*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*\{*\s*([A-Z]|[a-z]|[0-9])*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*)+)+)";

        // ACTIONS  ERRORS
        private static string ACTIONSANDERRORS
            = @"^((\s*RESERVADAS\s*\(\s*\)\s*)+|{+\s*|(\s*[0-9]+\s*=\s*'([A-Z]|[a-z]|[0-9])+'\s*)+|}+\s*|(\s*([A-Z]|[a-z]|[0-9])\s*\(\s*\)\s*)+|{+\s*|(\s*[0-9]+\s*=\s*'([A-Z]|[a-z]|[0-9])+'\s*|}+\s)*(\s*ERROR\s*=\s*[0-9]+\s*))$"; 

<<<<<<< Updated upstream
        public static string AnalyseFile(string data, ref int line){
            string mensaje = "";
            bool first = true;
            bool setExists = false;
            bool actionsError = false;
            bool actionExists = false;

            int actionCount = 0;
            int actionError = 0;
            int tokenCount = 0;
            int setCount = 0;

            String[] lines = data.split('\n');
            int count = 0;

            foreach (var item in lines)
            {
                count++
                if(!string.IsNullOrWhiteSpace(item) && !string.IsNullOrEmpty(item))
                {
                    if(first)
                    {
                        first = false;
                        if(item.Contains("SETS"))
                        {
                            setExists = true;
                            mensaje = "Formato Correcto";
                        }
                        else if (item.Contains("TOKENS"))
                 {
                     tokenExists = true;
                     mensaje = "Formato Correcto";
                 }
                 else
                 {
                     line = 1;
                     return "Error en linea 1: Se esperaba SETS o TOKENS";
                 }
             }
             else if (setExists)
             {
                 Match setMatch = Regex.Match(item, SETS);
                 if (item.Contains("TOKENS"))
                 {
                     if (setCount < 1)
                     {
                         line = count;
                         return "Error: Se esperaba almenos un SET";
                     }
                     setExists = false;
                     tokenExists = true;
                 }
                 else
                 {
                     if (!setMatch.Success)
                     {
                         return $"Error en linea: {count}";
                     }
                     tokenCount++;
                 }

                 setCount++;
             }
            }
             //   
            }
        }
=======
        public static Dictionary<int, string> actionReference = new Dictionary<int, string>();


        
    }


}
