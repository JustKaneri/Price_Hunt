namespace Auth_Servise.IntefaceRepository
{
    public interface IEmailCheck
    {
        /// <summary>
        /// Проверка синтаксиса почты
        /// </summary>
        /// <param name="email">почта</param>
        /// <returns>True если почта правильная, False если нет</returns>
        public bool CorrectSyntax(string email);

        /// <summary>
        /// Проверка существует ли почта
        /// </summary>
        /// <param name="email">почта</param>
        /// <returns>True если почта существует, False если не существует</returns>
        public bool CheckExist(string email);
    }
}
