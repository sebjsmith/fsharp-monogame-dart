module Circle

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System

// Ported from C# http://www.adamkdean.co.uk/circle-primitive-class-for-xna-monogame
type Circle(x : float, y : float, radius: float, color : Color, graphics : GraphicsDeviceManager) =
    let color = color
    let calculatePointCount = (int (Math.Ceiling(radius * Math.PI)))
    let pointTheta = (Math.PI * (float 2)) / (float (calculatePointCount - 1))
    let vertices = [ for i in 0 .. calculatePointCount -> VertexPositionColor(Vector3((float32 (x + (Math.Sin(pointTheta * (float i)) * radius))), ((float32 (y + (Math.Cos(pointTheta * (float i)) * radius)))), 0.0f), color)] |> List.toArray

    member c.Draw() =
        let mutable effect = new BasicEffect(graphics.GraphicsDevice)
        effect.VertexColorEnabled <- true
        effect.Projection <- Matrix.CreateOrthographicOffCenter(0.0f, (float32 graphics.GraphicsDevice.Viewport.Width), (float32 graphics.GraphicsDevice.Viewport.Height), 0.0f, 0.0f, 1.0f)
        do effect.CurrentTechnique.Passes.[0].Apply()
        do graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, vertices, 0, vertices.Length - 1);