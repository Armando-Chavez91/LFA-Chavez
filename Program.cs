namespace Fase1_LFA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para personalizar la configuraci�n de la aplicaci�n, como establecer configuraciones de alta DPI o la fuente predeterminada,
            // https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}