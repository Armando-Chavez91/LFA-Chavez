using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


     public class FormatoGramatica
    {
        //SETS
        
        private static string SETS = @"^(\s*([A-Z])+\s*=\s*((((\'([A-Z]|[a-z]|[0-9]|_)\'\.\.\'([A-Z]|[a-z]|[0-9]|_)\')\+)*(\'([A-z]|[a-z]|[0-9]|_)\'\.+\'([A-z]|[a-z]|[0-9]|_)\')*(\'([A-z]|[a-z]|[0-9]|_)\')+)|(CHR\(+([0-9])+\)+\.\.CHR\(+([0-9])+\)+)+)\s*)";

        //TOKENS
        private static string TOKENS = @"^(\s*TOKEN\s*[0-9]+\s*=\s*(([A-Z]+)|((\'*)([a-z]|[A-Z]|[1-9]|(\<|\>|\=|\+|\-|\*|\(|\)|\{|\}|\[|\]|\.|\,|\:|\;))(\'))+|((\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*([A-Z]|[a-z]|[0-9]|\')*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*([A-Z]|[a-z]|[0-9])*\s*\)*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*\{*\s*([A-Z]|[a-z]|[0-9])*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*(\||\'|\*|\?|\[|\]|\{|\}|\(|\)|\\)*\s*)+)+)";

        //ACTIONS and ERRORS
        private static string ACTIONSANDERRORS
            = @"^((\s*RESERVADAS\s*\(\s*\)\s*)+|{+\s*|(\s*[0-9]+\s*=\s*'([A-Z]|[a-z]|[0-9])+'\s*)+|}+\s*|(\s*([A-Z]|[a-z]|[0-9])\s*\(\s*\)\s*)+|{+\s*|(\s*[0-9]+\s*=\s*'([A-Z]|[a-z]|[0-9])+'\s*|}+\s)*(\s*ERROR\s*=\s*[0-9]+\s*))$";

        public static Dictionary<int, string> actionReference = new Dictionary<int, string>();

        public static string AnalyseFile(string data, ref int line)
        {
            // Variable para almacenar el mensaje de estado
            string mensaje = "";

            // Variables de estado
            bool first = true;
            bool setExists = false;
            bool tokenExists = false;
            bool actionExists = false;

            // Contadores
            int actionCount = 0;
            int actionsError = 0;
            int tokenCount = 0;
            int setCount = 0;

            // Dividir los datos en líneas
            string[] lines = data.Split('\n');
            int count = 0;

            // Iterar sobre cada línea de los datos
            foreach (var item in lines)
            {
                count++;
                // Verificar si la línea no está en blanco o es nula
                if (!string.IsNullOrWhiteSpace(item) && !string.IsNullOrEmpty(item))
                {
                    // Verificar el estado de la primera línea
                    if (first)
                    {
                        first = false;
                        // Verificar si la primera línea contiene "SETS" o "TOKENS"
                        if (item.Contains("SETS"))
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
                    // Verificar si los conjuntos están siendo definido
                    else if (setExists)
                    {
                        Match setMatch = Regex.Match(item, SETS);
                        // Verificar si se está pasando a la sección de TOKENS
                        if (item.Contains("TOKENS"))
                        {
                            // Verificar si se ha definido al menos un conjunto
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
                            // Verificar si la línea coincide con el formato de conjunto esperado
                            if (!setMatch.Success)
                            {
                                return $"Error en linea: {count}";
                            }
                            tokenCount++;
                        }

                        setCount++;
                    }
                    // Verificar si los tokens están siendo definidos
                    else if (tokenExists)
                    {
                        Match m = Regex.Match(item, TOKENS);
                        // Verificar si se está pasando a la sección de ACTIONS
                        if (item.Contains("ACTIONS"))
                        {
                            // Verificar si se ha definido al menos un token
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
                            // Verificar si la línea coincide con el formato de token esperado
                            if (!m.Success)
                            {
                                return $"Error en linea: {count}";
                            }
                            tokenCount++;
                        }
                    }
                    // Verificar si las acciones están siendo definidas
                    else if (actionExists)
                    {
                        // Contar las líneas que contienen "ERROR"
                        if (item.Contains("ERROR"))
                        {
                            actionsError++;
                        }
                        // Verificar si la línea coincide con el formato de acción esperado
                        Match actMatch = Regex.Match(item, ACTIONSANDERRORS);
                        if (!actMatch.Success)
                        {
                            return $"Error en linea: {count}";
                        }
                    }
                }
            }
            // Verificar si se ha definido al menos una acción
            if (actionCount < 1)
            {
                return $"Error: Se esperaba la sección de ACTIONS";
            }
            // Verificar si se ha definido al menos una línea de error
            if (actionsError < 1)
            {
                return $"Error: Se esperaba una la sección de ERROR";
            }
            // Asignar el número de línea actualizado y devolver el mensaje de estado
            line = count;
            return mensaje;
        }



       

  
        private static void AddNewSET(ref Dictionary<string, string[]> sets, string text)
        {
            // Lista para almacenar los valores ASCII del conjunto
            List<string> asciiValues = new List<string>();
            string setName = "";

            // Divide la línea en el nombre del conjunto y los valores ASCII asociados
            string[] line = text.Split('=');

            // Asigna el nombre del conjunto, eliminando espacios en blanco alrededor
            setName = line[0].Trim();
            // Elimina los espacios en blanco de la lista de valores ASCII
            line[1] = line[1].Replace(" ", "");

            // Divide los valores ASCII por el operador '+'
            string[] values = line[1].Split('+');

            // Itera sobre los valores ASCII
            foreach (var item in values)
            {
                // Divide los límites de cada valor por el operador '.'
                string[] tmpLimits = item.Split('.');

                // Lista para almacenar los límites válidos
                List<string> Limits = new List<string>();

                // Agrega los límites válidos a la lista
                foreach (var i in tmpLimits)
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        Limits.Add(i);
                    }
                }

                // Si hay dos límites, obtiene el rango de valores ASCII
                if (Limits.Count == 2)
                {
                    int lowerLimit = formatSET(Limits[0]);
                    int upperLimit = formatSET(Limits[1]); ;

                    // Agrega el rango de valores ASCII a la lista
                    asciiValues.Add($"{lowerLimit},{upperLimit}");
                }
                // Si hay un límite, obtiene el valor ASCII único
                else if (Limits.Count == 1)
                {
                    int character = formatSET(Limits[0]); // Obtiene el valor ASCII del carácter

                    // Agrega el valor ASCII único a la lista
                    asciiValues.Add(character.ToString());
                }
            }

            // Verifica que el nombre del conjunto tenga más de un carácter
            if (setName.Length > 1)
            {
                // Agrega el conjunto al diccionario de conjuntos, con el nombre como clave y los valores ASCII como valor
                sets.Add(setName, asciiValues.ToArray());
            }
            else
            {
                // Si el nombre del conjunto es demasiado corto, lanza una excepción
                throw new Exception($"El nombre del SET {setName} debe ser mas largo.");
            }

        }



        private static int formatSET(string token)
        {
            int result;

            // Verifica si el token contiene la palabra "CHR"
            if (token.Contains("CHR")) 
            {
                // Extrae el valor del token entre paréntesis y elimina cualquier espacio en blanco
                string value = token.Replace("CHR", "");
                value = value.Replace("(", "");
                value = value.Replace(")", "");
                value = value.Replace(" ", "");

                // Convierte el valor a un número entero
                result = Convert.ToInt16(value);
            }
            else // Si el token no contiene "CHR"
            {
                // Obtiene el código ASCII del segundo carácter del token y lo asigna como resultado
                result = Encoding.ASCII.GetBytes(token)[1];
            }

            return result;
        }

        
        private static void AddNewTOKEN(ref List<int> tokenNumbers, ref string tokens, string text) 
        {
            // Elimina la palabra "TOKEN" y cualquier espacio en blanco al principio o al final de la cadena
            text = text.Replace("TOKEN", "");
            text = text.Trim();
            int tokenNumber = 0;

            // Divide la línea en el número del token y la acción asociada
            string[] line = SplitToken(text);

            // Intenta convertir el número del token a un entero
            if (int.TryParse(line[0].Trim(), out tokenNumber)) 
            {
                // Si el número del token no está en la lista de números de token, lo agrega
                if (!tokenNumbers.Contains(tokenNumber))
                {
                    tokenNumbers.Add(tokenNumber);
                }
                else  // Si el número del token ya está en la lista, lanza una excepción
                {
                    throw new Exception($"El TOKEN {tokenNumber} aparece mas de una vez.");
                }
            }
            else // Si el número del token no es un número válido, lanza una excepción
            {
                throw new Exception($"El nombre del TOKEN {line[0]} no es valido.");
            }


            // Obtiene la nueva acción del token y elimina cualquier espacio en blanco alrededor de ella
            string newToken = line[1].Trim();

            // Si la cadena de tokens está vacía o solo contiene espacios en blanco, añade la nueva acción sin unión
            if (string.IsNullOrEmpty(tokens) | string.IsNullOrWhiteSpace(tokens))
            {
                tokens = $"({newToken})";
            }
            else // Si la cadena de tokens ya contiene acciones, añade la nueva acción con unión
            {
                tokens += $"|({newToken})";
            }
        }


        private static string[] SplitToken(string expression)
        {
            string functionName = ""; // Almacena el nombre de la función dentro del token
            string[] token = { "", "" }; // Arreglo para almacenar el nombre del token y su acción

            for (int i = 0; i < expression.Length; i++)
            {
                // Si el carácter actual no es '=', se agrega al nombre del token
                if (expression[i] != '=')
                {
                    token[0] += expression[i]; // Concatenación del carácter al nombre del token
                }
                else // Si se encuentra el signo '=', se asume que el nombre del token ha terminado
                {
                    string tmp = "";

                    // Se extrae la acción a partir del siguiente carácter después del '='
                    for (int j = i + 1; j < expression.Length; j++)
                    {
                        tmp += expression[j];
                    }

                    // Se elimina cualquier acción entre llaves y se obtiene el nombre de la función si existe
                    token[1] = removeActionsFromExpression(tmp, ref functionName); 
                    token[1] = token[1].Trim();
                    break; // Se termina el bucle una vez que se ha encontrado la acción
                }
            }

            // Si se encontró el nombre de la función en la acción
            if (!string.IsNullOrEmpty(functionName))
            {
                // Se intenta convertir el nombre del token a un número entero para asignar la función a ese token
                if (int.TryParse(token[0].Trim(), out int tokenNumber))
                {
                    // Se agrega la referencia de la acción al diccionario actionReference con el número de token como clave
                    actionReference.Add(tokenNumber, functionName.Trim());
                }
                else // Si el nombre del token no es un número válido
                {
                    // Se lanza una excepción indicando que el nombre del token no es válido
                    throw new Exception($"El nombre del TOKEN {token[0]} no es valido.");
                }

            }

            // Se devuelve el arreglo con el nombre del token y la acción asociada
            return token;
        }


        private static string removeActionsFromExpression(string text, ref string functionName)
        {
            // Inicialización de la cadena de resultado
            string result = "";

            // Verifica si la cadena de texto contiene llaves
            if (text.Contains('{') && text.Contains('}'))
            {
                // Recorre cada carácter de la cadena de texto
                for (int i = 0; i < text.Length; i++)
                {
                    // Si el carácter actual es una comilla simple ('), se concatena al resultado y avanza dos posiciones  
                    if (text[i] == '\'')
                    {
                        result += $"'{text[i + 1]}'";
                        i += 2;
                    }
                    // Si el carácter actual es una llave de apertura ({)
                    else if (text[i] == '{')
                    {
                        int counter = 0;
                        char? actualChar = text[i];
                        
                        // Mientras no se encuentre una llave de cierre (})
                        while (actualChar != '}')
                        {
                            counter++;
                            actualChar = text[i + counter];
                            functionName += actualChar;
                        }

                        // Se eliminan los caracteres adicionales y se limpia el nombre de la función
                        functionName = functionName.Replace("}", "");
                        functionName = functionName.Replace(" ", "");

                        i += counter;
                    }
                    // Si el carácter actual no es una comilla simple (') ni una llave de apertura ({), se agrega al resultado
                    else
                    {
                        result += text[i];
                    }
                }
                // Se devuelve el resultado sin las acciones entre llaves
                return result;
            }
            // Si no se encuentran llaves en la cadena de texto, se devuelve la cadena original
            return text;
        }


    }

