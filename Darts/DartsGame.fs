module DartsGame
 
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open Circle
 
type DartsGame () as x =
    inherit Game()
 
    let graphics = new GraphicsDeviceManager(x)
 
    override x.Initialize() =
        do base.Initialize()
        ()
 
    override x.LoadContent() =
        ()
 
    override x.Update (gameTime) =
        ()
 
    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.Black
        let bull = new Circle(100.0, 100.0, 10.0, graphics)
        do bull.Draw()
        let outerbull = new Circle(100.0, 100.0, 25.0, graphics)
        do outerbull.Draw()
        let board = new Circle(100.0, 100.0, 100.0, graphics)
        do board.Draw()
        ()