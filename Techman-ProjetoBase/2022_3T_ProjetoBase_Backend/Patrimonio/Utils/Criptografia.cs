﻿namespace Patrimonio.Utils
{
    public static class Criptografia
    {

        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Comparar(string senhaLogin, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaLogin, senhaBanco);
        }
       
    }
}
