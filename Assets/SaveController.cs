using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveController 
{

    public const string PlayerPositionKey = "PlayerTransform";

    public static void SavePlayePosition(Transform player)
    {
        var value = GetTransformSaveString(player);
        PlayerPrefs.SetString(PlayerPositionKey, value);
    }

    public static void LoadPlayerPosition(Transform player)
    {
        if (PlayerPrefs.HasKey(PlayerPositionKey))
        {
            var value = PlayerPrefs.GetString(PlayerPositionKey);

            LoadTransformFromSaveString(player, value);
        }
    }


    private static void LoadTransformFromSaveString(Transform playerTransform, string saveString)
    {
        
        string[] parts = saveString.Split(';');
        if (parts.Length != 2)
        {
            Debug.LogError("Invalid save string format");
            return;
        }

       
        string[] positionParts = parts[0].Split(',');
        if (positionParts.Length == 3 &&
            float.TryParse(positionParts[0], out float posX) &&
            float.TryParse(positionParts[1], out float posY) &&
            float.TryParse(positionParts[2], out float posZ))
        {
            playerTransform.position = new Vector3(posX, posY, posZ);
        }
        else
        {
            Debug.LogError("Invalid position data in save string");
            return;
        }

     
        string[] rotationParts = parts[1].Split(',');
        if (rotationParts.Length == 3 &&
            float.TryParse(rotationParts[0], out float rotX) &&
            float.TryParse(rotationParts[1], out float rotY) &&
            float.TryParse(rotationParts[2], out float rotZ))
        {
            playerTransform.eulerAngles = new Vector3(rotX, rotY, rotZ);
        }
        else
        {
            Debug.LogError("Invalid rotation data in save string");
        }
    }


    private static string GetTransformSaveString(Transform playerTransform)
    {
        Vector3 position = playerTransform.position;
        Vector3 eulerAngles = playerTransform.eulerAngles;


        string saveString = $"{position.x},{position.y},{position.z};{eulerAngles.x},{eulerAngles.y},{eulerAngles.z}";
        return saveString;
    }

}
