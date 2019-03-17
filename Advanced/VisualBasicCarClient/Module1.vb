Imports CarLibrary

Module Module1

    Sub Main()
        Dim MiniVan As New MiniVan()
        MiniVan.TurboBoost()

        Dim SportsCar As New SportsCar()
        SportsCar.TurboBoost()

        Dim dreamCar As New PerfomanceCar()
        dreamCar.Name = "Hank"
        dreamCar.TurboBoost()


        Console.ReadLine()
    End Sub

End Module

Public Class PerfomanceCar
    Inherits SportsCar

    Public Overrides Sub TurboBoost()
        Console.WriteLine("Zero to 60 in a cool 4.8 seconds...")
    End Sub
End Class
