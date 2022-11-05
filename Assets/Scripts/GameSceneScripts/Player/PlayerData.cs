using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// POCO class для хранения данных (но имеет дополнительные методы). Реализован с помощью паттерна Singleton
/// </summary>
public class PlayerData
{
    #region JsonProperties
    /// <summary>
    /// Имя игрока
    /// </summary>
    [JsonProperty("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Рекордное количество поинтов за матч
    /// </summary>
    [JsonProperty("Record")]
    public float Record { get; set; }

    /// <summary>
    /// Всего очков набрано за все игры
    /// </summary>
    [JsonProperty("TotalPoints")]
    public float TotalPoints { get; set; }

    /// <summary>
    /// Всего игр проведено
    /// </summary>
    [JsonProperty("GamesCount")]
    public int GamesCount { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    [JsonProperty("DateRegister")]
    public string DateRegister;

    #endregion

    // имя json файла где хранятся данные
    private const string FILE_NAME = "PlayerData.json";
    // наш единственный объект игрока 
    private static PlayerData _instance;

    private PlayerData() {}

    #region DataLogic
    public static PlayerData GetInstance()
    {
        _instance ??= GetPlayerData();
        return _instance;
    }
    public void Save()
    {
        File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(this));
    }
    private static PlayerData GetPlayerData()
    {
        var content = File.Exists(FILE_NAME) ? File.ReadAllText(FILE_NAME) : null;
        if (content is null)
            return new PlayerData();

        return JsonConvert.DeserializeObject<PlayerData>(content);
    }
    #endregion

    #region Methods
    public bool CheckInputName(string name)
    {
        return Regex.IsMatch(name, "^[a-z0-9_]+$", RegexOptions.IgnoreCase);
    } 
    public void SetName(string name)
    {
        Name = name;
        // да, именно при установке имени задаем дату регистрации, не нужно аплодисментов
        DateRegister = DateTime.Now.ToShortDateString();
    }
    public string GetStatistics()
    {
        return $"Name: {Name}\n" +
            $"Record: {Record}\n" +
            $"Total points: {TotalPoints}\n" +
            $"Games: {GamesCount}";
    }
    #endregion
}
