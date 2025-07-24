using System;
using Spectre.Console;

class FrasesService
{
    public static void Frases()
    {
        // Título en grande
        AnsiConsole.Write(
            new FigletText("Frases Tech")
                .Centered()
                .Color(Color.Blue));

        // Frases en paneles separados
        AnsiConsole.Write(new Panel("[bold yellow]“La innovación es lo que distingue a un líder de un seguidor.”[/]\n[italic]– Steve Jobs[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Yellow))
            .Padding(1, 1)
            .Header("Steve Jobs", Justify.Center));

        AnsiConsole.Write(new Panel("[bold green]“Está bien celebrar el éxito, pero es más importante prestar atención a las lecciones del fracaso.”[/]\n[italic]– Bill Gates[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Green))
            .Padding(1, 1)
            .Header("Bill Gates", Justify.Center));

        AnsiConsole.Write(new Panel("[bold cyan]“Cuando algo es lo suficientemente importante, lo haces incluso si las probabilidades no están a tu favor.”[/]\n[italic]– Elon Musk[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.DarkBlue))
            .Padding(1, 1)
            .Header("Elon Musk", Justify.Center));

        AnsiConsole.Write(new Panel("[bold magenta]“El mayor riesgo es no tomar ningún riesgo.”[/]\n[italic]– Mark Zuckerberg[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Magenta1))
            .Padding(1, 1)
            .Header("Mark Zuckerberg", Justify.Center));

        AnsiConsole.Write(new Panel("[bold red]“Si no puedes tolerar las críticas, no hagas nada nuevo ni interesante.”[/]\n[italic]– Jeff Bezos[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Red))
            .Padding(1, 1)
            .Header("Jeff Bezos", Justify.Center));

        AnsiConsole.Write(new Panel("[bold blue]“Si vamos a hacer algo revolucionario, pensémoslo en grande.”[/]\n[italic]– Larry Page[/]")
            .Border(BoxBorder.Rounded)
            .BorderStyle(new Style(Color.Blue))
            .Padding(1, 1)
            .Header("Larry Page", Justify.Center));
    }
}
