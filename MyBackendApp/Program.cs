var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS configuration here
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://127.0.0.1:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy here
app.UseCors("AllowReactApp");

// Mood-based encouragement data
var encouragements = new Dictionary<string, string[]>
{
    ["happy"] = new[]
    {
        "That's wonderful! Keep spreading those positive vibes! 🌟",
        "Your happiness is contagious! Share it with the world! ✨",
        "Amazing! Ride this wave of joy as far as it takes you! 🌊",
        "Fantastic! Your smile can light up someone's day! 😊"
    },
    ["sad"] = new[]
    {
        "It's okay to feel sad sometimes. You're stronger than you know. 💙",
        "This feeling will pass. You've overcome challenges before, and you will again. 🌈",
        "Your feelings are valid. Take time to heal, you deserve kindness. 🤗",
        "Tomorrow is a new day full of possibilities. You've got this! 🌅"
    },
    ["stressed"] = new[]
    {
        "Take a deep breath. You're handling more than you think. 🌸",
        "Break it down into small steps. You don't have to do everything at once. 🪜",
        "Remember: you've survived 100% of your worst days. You're resilient! 💪",
        "It's okay to ask for help. You don't have to face everything alone. 🤝"
    },
    ["excited"] = new[]
    {
        "Your enthusiasm is inspiring! Channel that energy into something amazing! ⚡",
        "Yes! That excitement will fuel incredible things! 🚀",
        "Your passion is your superpower! Use it wisely! 🔥",
        "Excitement is the fuel of achievement. You're going places! 🎯"
    },
    ["tired"] = new[]
    {
        "Rest is not a luxury, it's a necessity. Be kind to yourself. 😴",
        "Your body and mind need recovery. It's okay to slow down. 🌙",
        "Even superheroes need to recharge. Take the rest you deserve. ⭐",
        "Listen to your body. Rest now so you can shine tomorrow. 🌻"
    },
    ["anxious"] = new[]
    {
        "You're not alone in this feeling. Focus on what you can control. 🌱",
        "Breathe slowly. This moment will pass, and so will this feeling. 🍃",
        "Anxiety lies to you. You're more capable than your worries suggest. 🦋",
        "One step at a time. You don't need to solve everything right now. 🌿"
    }
};

// Get all available moods
app.MapGet("/moods", () =>
{
    return encouragements.Keys.Select(mood => new { Mood = mood }).ToArray();
})
.WithName("GetMoods")
.WithOpenApi()
.WithSummary("Get all available moods");

// Get encouragement for a specific mood
app.MapGet("/encouragement/{mood}", (string mood) =>
{
    mood = mood.ToLower();

    if (!encouragements.ContainsKey(mood))
    {
        return Results.BadRequest(new { error = $"Mood '{mood}' not found. Available moods: {string.Join(", ", encouragements.Keys)}" });
    }

    var messages = encouragements[mood];
    var randomMessage = messages[Random.Shared.Next(messages.Length)];

    return Results.Ok(new EncouragementResponse(mood, randomMessage, DateTime.Now));
})
.WithName("GetEncouragement")
.WithOpenApi()
.WithSummary("Get an encouraging message for your current mood");

// Post your mood and get encouragement
app.MapPost("/mood", (MoodRequest request) =>
{
    var mood = request.Mood.ToLower();

    if (!encouragements.ContainsKey(mood))
    {
        return Results.BadRequest(new { error = $"Mood '{mood}' not found. Available moods: {string.Join(", ", encouragements.Keys)}" });
    }

    var messages = encouragements[mood];
    var randomMessage = messages[Random.Shared.Next(messages.Length)];

    return Results.Ok(new EncouragementResponse(mood, randomMessage, DateTime.Now));
})
.WithName("PostMood")
.WithOpenApi()
.WithSummary("Share your mood and receive encouragement");

// Get a random daily encouragement
app.MapGet("/daily-encouragement", () =>
{
    var allMessages = encouragements.Values.SelectMany(x => x).ToArray();
    var randomMessage = allMessages[Random.Shared.Next(allMessages.Length)];

    return new { message = randomMessage, date = DateOnly.FromDateTime(DateTime.Now) };
})
.WithName("GetDailyEncouragement")
.WithOpenApi()
.WithSummary("Get a random daily dose of encouragement");

app.Run();

// Request and Response models
record MoodRequest(string Mood);
record EncouragementResponse(string Mood, string Message, DateTime Timestamp);
