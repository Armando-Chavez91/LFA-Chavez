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
             bool tokenExists = false;
             bool actionExists = false;
        
             int actionCount = 0;
             int actionsError = 0;
             int tokenCount = 0;
             int setCount = 0;

            String[] lines = data.Split('\n');
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
                     else if (tokenExists)
             {
                 Match m = Regex.Match(item, TOKENS);
                 if (item.Contains("ACTIONS"))
                 {
                     if (tokenCount < 1)
                     {
                         line = count;
                         return "Error: Se esperaba almenos un TOKEN";
                     }
                     actionCount++;
                     tokenExists = false;
                     actionExists = true;
                 }
                 else
                 {
                     if (!m.Success)
                     {
                         return $"Error en linea: {count}";
                     }
                     tokenCount++;
                 }
             }
             else if (actionExists)
             {
                 if (item.Contains("ERROR"))
                 {
                     actionsError++;
                 }
                 Match actMatch = Regex.Match(item, ACTIONSANDERRORS);
                 if (!actMatch.Success)
                 {
                     return $"Error en linea: {count}";
                 }
             }
        
            
                if (actionCount < 1)
     {
         return $"Error: Se esperaba la sección de ACTIONS";
     }
     if (actionsError < 1)
     {
         return $"Error: Se esperaba una la sección de ERROR";
     }
     line = count;
     return mensaje;
 } 
}
}

 private static string removeActionsFromExpression(string text, ref string functionName)
 {
     //Remove everything contained within {}
     string result = "";

     if (text.Contains('{') && text.Contains('}'))
     {
         for (int i = 0; i < text.Length; i++)
         {
             if (text[i] == '\'')
             {
                 result += $"'{text[i + 1]}'";
                 i += 2;
             }
             
             else
             {
                 result += text[i];
             }
         }
         return result;
     }

     return text;
 }
        
 private static string[] SplitToken(string expression)
 {
     string functionName = "";
     string[] token = { "", "" };

     for (int i = 0; i < expression.Length; i++)
     {
         if (expression[i] != '=')
         {
             token[0] += expression[i]; 
         }
         else //borrar signos de =
         {
             string tmp = "";

             for (int j = i + 1; j < expression.Length; j++)
             {
                 tmp += expression[j];
             }

             token[1] = removeActionsFromExpression(tmp, ref functionName); 
             token[1] = token[1].Trim();
             break;
         }
     }

    
            if (!string.IsNullOrEmpty(functionName))
            {
                if (int.TryParse(token[0].Trim(), out int tokenNumber))
                {
                    actionReference.Add(tokenNumber, functionName.Trim());
                }
                else
                {
                    throw new Exception($"El nombre del TOKEN {token[0]} no es valido.");
                }

            }
     return token;
 }

private static void CheckForRepeatedTokens(List<int> tokens, List<Action> actionsList) 
{
    List<int> repeated = new List<int>();

    foreach (var action in actionsList)
    {
        foreach (var item in action.ActionValues.Keys)
        {
            if (repeated.Contains(item) || tokens.Contains(item))
            {
                throw new Exception($"Error: El token {item} aparece más de una vez");
            }
            else
            {
                repeated.Add(item);
            }
        }
    }
}
    
 private static void AddNewSET(ref Dictionary<string, string[]> sets, string text)
 {
     List<string> asciiValues = new List<string>();
     string setName = "";

     string[] line = text.Split('=');

     setName = line[0].Trim();
     line[1] = line[1].Replace(" ", "");

     string[] values = line[1].Split('+');

     foreach (var item in values)
     {
         string[] tmpLimits = item.Split('.');

         List<string> Limits = new List<string>();

         //format
         foreach (var i in tmpLimits)
         {
             if (!string.IsNullOrEmpty(i))
             {
                 Limits.Add(i);
             }
         }

         if (Limits.Count == 2)
         {
             int lowerLimit = formatSET(Limits[0]);
             int upperLimit = formatSET(Limits[1]); ;

        
             asciiValues.Add($"{lowerLimit},{upperLimit}");
         }
         else if (Limits.Count == 1)
         {
             int character = formatSET(Limits[0]);

             asciiValues.Add(character.ToString());
         }
     }
          if (setName.Length > 1)
     {
         sets.Add(setName, asciiValues.ToArray());
     }
     else
     {
         throw new Exception($"El nombre del SET {setName} debe ser mas largo.");
     }

 }

 private static int formatSET(string token)
 {
     int result;

     if (token.Contains("CHR")) 
     {
         string value = token.Replace("CHR", "");
         value = value.Replace("(", "");
         value = value.Replace(")", "");
         value = value.Replace(" ", "");

         result = Convert.ToInt16(value);
     }
     else 
     {
         result = Encoding.ASCII.GetBytes(token)[1];
     }

     return result;
 }
         private static void AddNewTOKEN(ref List<int> tokenNumbers, ref string tokens, string text) 
 {
     text = text.Replace("TOKEN", "");
     text = text.Trim();
     int tokenNumber = 0;

     string[] line = SplitToken(text);

    
     if (int.TryParse(line[0].Trim(), out tokenNumber)) 
     {
         if (!tokenNumbers.Contains(tokenNumber))
         {
             tokenNumbers.Add(tokenNumber);
         }
         else
         {
             throw new Exception($"El TOKEN {tokenNumber} aparece mas de una vez.");
         }
     }
     else
     {
         throw new Exception($"El nombre del TOKEN {line[0]} no es valido.");
     }
         string newToken = line[1].Trim();

     if (string.IsNullOrEmpty(tokens) | string.IsNullOrWhiteSpace(tokens))
     {
         tokens = $"({NuevoToken})";
     }
     else
     {
         tokens += $"|({NuevoToken})";
     }
 }
        }

        public static Dictionary<int, string> actionReference = new Dictionary<int, string>();
    }
}
