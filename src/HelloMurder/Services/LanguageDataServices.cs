using Murder.Assets;
using Murder.Assets.Localization;
using Murder.Data;

namespace HelloMurder.Services
{
    internal class LanguageDataServices
    {
        public static void ChangeToNextLanguage(LanguageId id, GameDataManager dataManager, GameProfile profile)
        {
            List<string> localizationAssets = [..
                dataManager.GetAllAssets()
                .Where(asset => asset is LocalizationAsset)
                .Select(a => a.Guid.ToString())
];

            List<LanguageId> languageIds = [..
                 profile.LocalizationResources.Keys
                .Where(k => localizationAssets.Contains(profile.LocalizationResources[k].ToString()))
            ];

            var nextLanguageId = languageIds[
                (languageIds.IndexOf(id) + 1)
                % languageIds.Count
            ];
            dataManager.ChangeLanguage(nextLanguageId);
        }
    }
}
