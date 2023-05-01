﻿namespace Domain.Models;

public class Data
{
    public int Id { get; set; }
    public string Body { get; set; }

    public Data(int id, string body)
    {
        Id = id;
        Body = body;
    }
}