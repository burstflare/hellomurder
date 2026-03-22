using Bang;
using HelloMurder.Core.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Murder;
using Murder.Core.Geometry;
using Murder.Core.Graphics;
using Murder.Core.Input;
using Murder.Serialization;
using System.Text.Json;

namespace HelloMurder;

/// <summary>
/// <inheritdoc cref="IMurderGame"/>
/// </summary>
public class HelloMurderGame : IMurderGame
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string Name => "HelloMurder";

    public JsonSerializerOptions Options => HelloMurderSerializerOptionsExtensions.Options;
	
    public ComponentsLookup ComponentsLookup { get; } = new MurderComponentsLookup();

    public RenderContext CreateRenderContext(GraphicsDevice graphicsDevice,
                                             Camera2D camera,
                                             RenderContextFlags settings)
    {
        RenderContext renderContext = new(graphicsDevice, camera, settings);

        WindowChangeSettings windowChangeSettings = new(
            new Point(Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height)
        )
        {
            ScalingKind = Murder.Save.ScalingKind.Snap
        };

        renderContext.OnClientWindowChanged(windowChangeSettings);

        return renderContext;
    }

    public void Initialize()
    {
        Game.Input.RegisterAxes(InputAxis.Movement, [
            GamepadAxis.LeftThumb,
            GamepadAxis.Dpad,
        ]);

        Game.Input.Register(InputAxis.Ui,
            new InputButtonAxis(Keys.W, Keys.A, Keys.S, Keys.D),
            new InputButtonAxis(Keys.Up, Keys.Left, Keys.Down, Keys.Right));

        Game.Input.RegisterButton(MurderInputButtons.Submit, Keys.Space);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Keys.Enter);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Buttons.A);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Buttons.Y);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.B);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.Back);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.Start);
    }

}
