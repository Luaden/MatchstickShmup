using UnityEngine;

public interface ICameraController
{
    float SensitivityModifier { get; }
    float SpeedModifier { get; }
    void ToggleCameraControls(bool cameraControlOnOff);
    void RepositionCamera(Vector3 cameraPosition);
}
