using UnityEngine;
using Newtonsoft.Json;
using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class ProfileStorage : IProfileStorage
    {
        private IProfile _profile;
        private IConfigReader _configReader;

        private ProfileState _profileState;

        private const string ProfileKey = "Profile";

        public ProfileStorage(IProfile profile, IConfigReader configReader)
        {
            _profile = profile;
            _configReader = configReader;
        }

        public void Save()
        {
            var jsonString = JsonConvert.SerializeObject(_profileState);

            PlayerPrefs.SetString(ProfileKey, jsonString);
            PlayerPrefs.Save();
        }

        public void SetProfileState(ProfileState profileState)
        {
            _profile.SetState(profileState);
            _profileState = profileState;
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(ProfileKey))
            {
                var json = PlayerPrefs.GetString(ProfileKey);
                _profileState = JsonConvert.DeserializeObject<ProfileState>(json);
            }
            else
            {
                _profileState = _configReader.InitializeProfileState();
                Save();
            }

            _profile.SetState(_profileState);           
        }
    }
}