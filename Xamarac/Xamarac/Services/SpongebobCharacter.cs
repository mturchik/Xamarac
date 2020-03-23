using System;

namespace Xamarac.Services
{
    public enum SpongebobCharacter
    {
        Spongebob = 0,
        Patrick = 1,
        Squidward = 2,
        MrCrabs = 3
    }

    public static class SpongebobCharacterExtensions
    {
        public static string GetImageUrl(this SpongebobCharacter character)
        {
            switch (character)
            {
                case SpongebobCharacter.Spongebob:
                    return
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fs-media-cache-ak0.pinimg.com%2F736x%2F80%2Fa3%2F92%2F80a392b2c2c313fd5816159562176c51.jpg&f=1&nofb=1";
                case SpongebobCharacter.Patrick:
                    return
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fvignette.wikia.nocookie.net%2Fspongebob%2Fimages%2F1%2F18%2FPatrick_Star_stock_art.png%2Frevision%2Flatest%3Fcb%3D20181202213928%26path-prefix%3Did&f=1&nofb=1";
                case SpongebobCharacter.Squidward:
                    return
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fvignette.wikia.nocookie.net%2Fspongebob%2Fimages%2F0%2F05%2FSquidward_stock_art.png%2Frevision%2Flatest%2Fscale-to-width-down%2F350%3Fcb%3D20181202012421&f=1&nofb=1";
                case SpongebobCharacter.MrCrabs:
                    return
                        "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2Foriginals%2F09%2Fa3%2F41%2F09a341750b4ff184c968e9fdf20fbe50.png&f=1&nofb=1";
                default: throw new ArgumentOutOfRangeException(nameof(character), character, null);
            }
        }
    }
}