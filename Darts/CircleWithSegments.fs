module CircleWithSegments

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System

type numKind =
    | Even
    | Odd
 
let get_choice n =
    if n % 2 = 0 then
        Even
    else
        Odd

// Horrendous copy and paste of Circle...
type CircleWithSegments(x : float, y : float, radius: float, firstColor : Color, secondColor : Color, graphics : GraphicsDeviceManager) =
    let firstColor = firstColor
    let secondColor = secondColor
    let calculatePointCount = radius * Math.PI
    let segmentPointCount = calculatePointCount / 20.0

    let segmentColor n =
        match get_choice (int ((n+calculatePointCount/40.0)/segmentPointCount)) with
        | Even -> firstColor
        | Odd -> secondColor

    let pointTheta = (Math.PI * 2.0) / (calculatePointCount - 1.0)
    let vertices = [ for i in 0.0 .. calculatePointCount -> VertexPositionColor(Vector3((float32 (x + (Math.Sin(pointTheta * i) * radius))), ((float32 (y + (Math.Cos(pointTheta * i) * radius)))), 0.0f), segmentColor(i))] |> List.toArray

    member c.Draw() =
        let mutable effect = new BasicEffect(graphics.GraphicsDevice)
        effect.VertexColorEnabled <- true
        effect.Projection <- Matrix.CreateOrthographicOffCenter(0.0f, (float32 graphics.GraphicsDevice.Viewport.Width), (float32 graphics.GraphicsDevice.Viewport.Height), 0.0f, 0.0f, 1.0f)
        do effect.CurrentTechnique.Passes.[0].Apply()
        do graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, vertices, 0, vertices.Length - 1);