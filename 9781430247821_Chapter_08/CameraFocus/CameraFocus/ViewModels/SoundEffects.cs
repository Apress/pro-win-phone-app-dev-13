using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace CameraFocus.ViewModels
{
    public enum EffectTypes { Click, Error };

    public class SoundEffects : Dictionary<EffectTypes, SoundEffect>
    {
        public SoundEffects()
        {
            this.Add(EffectTypes.Click, LoadSoundEffect("Windows Navigation Start.wav"));
            this.Add(EffectTypes.Error, LoadSoundEffect("Windows Critical Stop.wav"));
        }

        private SoundEffect LoadSoundEffect(string fileName)
        {
            string path = "Assets/Sounds/" + fileName;
            StreamResourceInfo resource = Application.GetResourceStream(
                new Uri(path, UriKind.Relative));
            return SoundEffect.FromStream(resource.Stream);
        }

        public void Play(EffectTypes effectType)
        {
            var effect = this[effectType];
            if (effect != null)
            {
                FrameworkDispatcher.Update();
                effect.Play();
            }
        }
    }
}
