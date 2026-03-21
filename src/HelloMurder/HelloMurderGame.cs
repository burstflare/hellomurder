using Bang;
using Microsoft.Xna.Framework.Input;
using Murder;
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

    public void Initialize()
    {
        Game.Input.RegisterButton(MurderInputButtons.Submit, Keys.Space);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Keys.Enter);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Buttons.A);
        Game.Input.RegisterButton(MurderInputButtons.Submit, Buttons.Y);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.B);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.Back);
        Game.Input.RegisterButton(MurderInputButtons.Cancel, Buttons.Start);
    }

}
