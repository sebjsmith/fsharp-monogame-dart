open DartsGame
 
[<EntryPoint>]
let main argv =
    use g = new DartsGame()
    g.Run()
    0