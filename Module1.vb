Option Infer On
Module Module1

    Sub Main()
        Dim hostname As String = "M6" 'machine name Or IP
        Dim url As Opc.URL = New Opc.URL($"opcda://{hostname}/OPC.DeltaV.1")
        Dim opc_item As Opc.Da.Item = New Opc.Da.Item(New Opc.ItemIdentifier("TESTMOD/SGGN1/OUT.CV"))
        Dim server As Opc.Da.Server = New Opc.Da.Server(New OpcCom.Factory(), url)
        server.Connect(New Opc.ConnectData(Nothing, Nothing))

        Console.WriteLine("Esc key to exit")
        Do
            Do While Not Console.KeyAvailable
                Dim result = server.Read({opc_item})
                Console.WriteLine($"{result(0).ItemName}:{result(0).Value}")
                System.Threading.Thread.Sleep(1000)
            Loop
        Loop While (Console.ReadKey(True).Key <> ConsoleKey.Escape)
        server.Disconnect()
        Console.WriteLine("This should close connection to the server, key to continue")
        Console.ReadKey(True)

    End Sub

End Module
