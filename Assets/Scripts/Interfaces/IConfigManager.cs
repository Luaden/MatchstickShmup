using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigManager : IAudioController, ICameraController
{
    AudioController AudioController { get; }
    CameraController CameraController { get; }
}