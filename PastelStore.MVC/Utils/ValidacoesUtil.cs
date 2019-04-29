namespace PastelStore.MVC.Utils
{
    public class ValidacoesUtil
    {
        /// <sumarry> Valida o email do Usuário, Verifica se o mesmo possui @ e . e contem ao menos 6 caracteres.false </sumarry>
        /// <param name="email">Email do usuário</param>
        /// <returns>Retorna True caso o email seja válido caso contrário retorna
        ///false</returns>
        public static bool ValidadorDeEmail(string email){
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            return false;
        }

        public static bool ValidadorDeSenha(string senha, string confirmaSenha){
            if (senha.Equals(confirmaSenha) && senha.Length > 5){
                return true;
            }
            return false;
        }
    }
}