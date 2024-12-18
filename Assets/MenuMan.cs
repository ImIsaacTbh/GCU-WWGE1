
using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMan : MonoBehaviour
{
    public GameObject resolutionDropdown;
    public GameObject camera, mainCam;
    public GameObject mainMenu, optionsMenu;
    public GameObject gunSources;
    public DataStorage Settings;
    //Just a script to hold the menu methods and options screen stuff
    //Nothing complex to annotate
    
    private void Start()
    {
        Settings = DataStorage.Settings;
        //Screen.SetResolution(2560, 1080, FullScreenMode.FullScreenWindow, 179);
        PopulateResolutionDropdown();
        //i was hoping that this would stop the lag when you switch to the standard version of the song but it didnt
        Resources.Load<AudioClip>("Assets/Audio/NeonGrave.mp3");
    }
    
    //used a parameter so i didnt need to make tons of methods for the same thing
    public void HandleSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //just toggles overlays
    public void HandleOptionsButton()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void HandleQuitButton()
    {
        Application.Quit(0);
    }

    //converts the id of the dropdown option to the fullscreenmode enum and sets it
    public void ToggleFullscreen(TMP_Dropdown dropdown)
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, (FullScreenMode)dropdown.value, Screen.currentResolution.refreshRateRatio);
    }

    //just adds the resolutions to the dropdown in a nicer format
    public void PopulateResolutionDropdown()
    {
        var optionsForAspect = new List<TMP_Dropdown.OptionData>();
        foreach (Resolution r in Screen.resolutions)
        {
            optionsForAspect.Add(new($"{r.width}x{r.height}@{r.refreshRateRatio.value}"));
        }

        var dropdown = resolutionDropdown.GetComponent<TMP_Dropdown>();
        dropdown.AddOptions(optionsForAspect);
        var rs = Screen.currentResolution;
        dropdown.SetValueWithoutNotify(dropdown.options.FindIndex(x => x.text == $"{rs.width}x{rs.height}@{rs.refreshRateRatio.value}"));
    }

    //this is a bit funky but works
    public void HandleResolutionDropdown(TMP_Dropdown dropdown)
    {
        var splitString = dropdown.options[dropdown.value].text.Split('x');
        int width = int.Parse(splitString[0]);
        var heightAndRefresh = splitString[1].Split('@');
        int height = int.Parse(heightAndRefresh[0]);
        float refresh = float.Parse(heightAndRefresh[1]);
        var res = Screen.resolutions.FirstOrDefault(x =>
            x.height == height && x.width == width);
        Screen.SetResolution(res.width, res.height, Screen.fullScreenMode, 120);
        //Debug.LogError($"{Screen.currentResolution.width}x{Screen.currentResolution.height}@{Screen.currentResolution.refreshRateRatio.value}");
    }
    
    //fov slider that just interpolates between 30 and 90 by the value of the slider (slider starts at 0 so standard fov is 60)
    public void HandleFOVSlider(Slider slider)
    {
        camera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Lerp(30, 90, slider.value);
    }

    //these are the volume sliders, there is two of them because i use multiple cameras in the main scene with their
    //own audio sources so one does music for the game one does music for the menus
    public void HandleVolumeSlider(Slider slider)
    {
        float volume = Mathf.Lerp(0, 100, slider.value);
        Settings.Volume = volume;
        camera.GetComponent<AudioSource>().volume = volume/100;
    }
    
    public void HandleVolumeSliderGame(Slider slider)
    {
        float volume = Mathf.Lerp(0, 100, slider.value);
        mainCam.GetComponent<AudioSource>().volume = volume/100;
        Settings.Volume = volume;
        foreach(AudioSource a in gunSources.GetComponents<AudioSource>())
        {
            a.volume = Settings.Volume;
        }
    }

    //I thought this was a funny idea. I downloaded the standard rock version and then the acoustic version of
    //the same song (in the menu at least) and switch between them copying the time so they are in (roughly) the same
    //place
    public void HandlePeacefulToggleMenu()
    {
        if (Settings.PeacefulMusic)
        {
            Settings.PeacefulMusic = false;
            var audiosource = camera.GetComponent<AudioSource>();
            float time = audiosource.time;
            audiosource.clip = Settings.NeonGrave;
            audiosource.Play();
            audiosource.time = time;
        }
        else
        {
            Settings.PeacefulMusic = true;
            var audiosource = camera.GetComponent<AudioSource>();
            float time = audiosource.time;
            audiosource.clip = Settings.NeonGraveAcoustic;
            audiosource.Play();
            audiosource.time = time;
        }
    }
    
    //due to the same camera issue as before i had to have a different method for this too 
    public void HandlePeacefulToggleGame()
    {
        if (Settings.PeacefulMusic)
        {
            Settings.PeacefulMusic = false;
            var audiosource = mainCam.GetComponent<AudioSource>();
            float time = audiosource.time;
            audiosource.clip = Settings.WishYouTheBest;
            audiosource.Play();
            audiosource.time = time;
        }
        else
        {
            Settings.PeacefulMusic = true;
            var audiosource = mainCam.GetComponent<AudioSource>();
            float time = audiosource.time;
            audiosource.clip = Settings.MyImmortal;
            audiosource.Play();
            audiosource.time = time;
        }
    }
}
