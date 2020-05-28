namespace SegundoExamenParcial
{
    public static class ActualUser
    {
        private static string per;

        public static void addUser(string cadena)
        {
            per = cadena;
        }

        public static string Per
        {
            get => per;
        }
    }

}