using System;
using System.Collections.Generic;
using System.Linq;
using MageSurvivor.PlayerProfile;
using Newtonsoft.Json;
using UnityEngine;

namespace MageSurvivor
{
    public class ConfigReader : IConfigReader
    {
        private readonly IGameConfiguration _gameConfiguration;

        private const string ConfigsKey = "Configs";
        private const string InitializersKey = "Initializers";

        public ConfigReader()
        {
            var shop = ReadConfig<ShopConfig>(EConfigs.Shop, ConfigsKey);
            var characters = ReadConfig<List<CharacterConfig>>(EConfigs.Characters, ConfigsKey);

            _gameConfiguration = new GameConfiguration(shop, characters);
        }

        public IGameConfiguration GetGameConfiguration()
        {
            return _gameConfiguration;
        }

        public ProfileState InitializeProfileState()
        {
            var shop = ReadConfig<ShopState>(EConfigs.Shop, InitializersKey);
            var player = ReadConfig<PlayerState>(EConfigs.Player, InitializersKey);
            var characters = ReadConfig<List<CharacterState>>(EConfigs.Characters, InitializersKey);

            var profileState = new ProfileState()
            {
                ShopState = shop,
                PlayerState = player,
                Characters = characters.ToDictionary(x => x.Id)
            };

            return profileState;
        }

        private T ReadConfig<T>(EConfigs eConfigName, string folderName) where T : new()
        {
            var json = Resources.Load<TextAsset>($"{folderName}/{eConfigName}");
            if (json == null || string.IsNullOrEmpty(json.text))
            {
                throw new Exception($"Failed to find config: {eConfigName}");
            }

            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => throw args.ErrorContext.Error
            };

            var result = JsonConvert.DeserializeObject<T>(json.text, settings);

            return result;
        }        
    }
}
