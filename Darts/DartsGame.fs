module DartsGame
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open Circle
 
type DartsGame () as x =
    inherit Game()
 
    let board = 500.0

    let bullRatio = 0.02
    let outerBullRatio = 0.08
    let innerTrebleRatio = 0.46
    let outerTrebleRatio = 0.48
    let innerDoubleRatio = 0.74
    let outerDoubleRatio = 0.76

    let graphics = new GraphicsDeviceManager(x)
    do graphics.PreferredBackBufferHeight <- (int board * 2)
    do graphics.PreferredBackBufferWidth <- (int board * 2)

    override x.Initialize() =
        do base.Initialize()
        ()
 
    override x.LoadContent() =
        ()
 
    override x.Update (gameTime) =
        ()
 
    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.Gainsboro

        for i in 1.0 .. board * bullRatio do
            let bull = new Circle(board, board, i, Color.Red, graphics)
            do bull.Draw()

        for i in board * bullRatio + 1.0 .. board * outerBullRatio do
            let outerbull = new Circle(board, board, i, Color.Green, graphics)
            do outerbull.Draw()

        for i in board * outerBullRatio + 1.0 .. board * innerTrebleRatio do
            let innerTreble = new Circle(board, board, i, Color.LightGreen, graphics)
            do innerTreble.Draw()

        for i in board * innerTrebleRatio + 1.0 .. board * outerTrebleRatio do
            let treble = new Circle(board, board, i, Color.SkyBlue, graphics)
            do treble.Draw()

        for i in board * outerTrebleRatio + 1.0 .. board * innerDoubleRatio do
            let innerDouble = new Circle(board, board, i, Color.LightGreen, graphics)
            do innerDouble.Draw()

        for i in board * innerDoubleRatio + 1.0 .. board * outerDoubleRatio do
            let double = new Circle(board, board, i, Color.SkyBlue, graphics)
            do double.Draw()

        for i in board * outerDoubleRatio + 1.0 .. board do
            let board = new Circle(board, board, i, Color.Black, graphics)
            do board.Draw()
        ()