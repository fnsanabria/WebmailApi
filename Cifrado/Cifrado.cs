namespace Cifrado
{
    public class Cifrado
    {
     private  static string abc = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz0123456789";

       public static int llave = 17;

     public   static string cifrar(string mensaje, int desplazamiento)
        {
            String cifrado = "";
            if (desplazamiento > 0 && desplazamiento < abc.Length)
            {
                //recorre caracter a caracter el mensaje a cifrar
                for (int i = 0; i < mensaje.Length; i++)
                {
                    int posCaracter = getPosABC(mensaje[i]);
                    if (posCaracter != -1) //el caracter existe en la variable abc
                    {
                        int pos = posCaracter + desplazamiento;
                        //solo entra al bucle si pos es mayor o igual a abc y resta para tomar la posicion
                        while (pos >= abc.Length)
                        {
                            pos = pos - abc.Length;

                        }
                        //concatena al mensaje cifrado 
                        cifrado += abc[pos];
                    }
                    else//si no existe el caracter no se cifra

                    {
                        cifrado += mensaje[i];
                    }
                }

            }
            return cifrado;
        }

        /* 
        * El descifrado cesar es el procedimiento inverso al cifrado
       */
        public static string descifrar(string mensaje, int desplazamiento)
        {
            String descifrado = "";
            if (desplazamiento > 0 && desplazamiento < abc.Length)
            {
                for (int i = 0; i < mensaje.Length; i++)
                {
                    int posCaracter = getPosABC(mensaje[i]);
                    if (posCaracter != -1) //el caracter existe en la variable abc
                    {
                        int pos = posCaracter - desplazamiento;
                        //solo entra al bucle se pos es un numero negativo

                        while (pos < 0)
                        {
                            pos = pos + abc.Length;

                        }
                        descifrado += abc[pos];
                    }
                    else
                    {
                        //sino existe agrego sin cifrar
                        descifrado += mensaje[i];
                    }
                }

            }
            return descifrado;
        }

        /* obtiene la posicion del caracter pasado como parametro 
         * en la variable abc que es nuestro abecedario de cifrado/descifrado
        */
      private  static int getPosABC(char caracter)
        {
            for (int i = 0; i < abc.Length; i++)
            {
                if (caracter == abc[i])
                {
                    //retorna el numero de posicion
                    return i;
                }
            }
            return -1;// si retorna este valor es porque no esta en el abc y se deja como esta el caracter
        }



    }
}