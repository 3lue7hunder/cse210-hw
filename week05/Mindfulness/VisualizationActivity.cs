using System;
using System.Threading;

class VisualizationActivity : Activity
{
    private static readonly string[] Scenes =
    {
        "Imagine yourself on a peaceful beach. The sun is warm, the waves gently crash, and a light breeze touches your face.",
        "Picture yourself in a quiet forest. The trees sway gently, birds sing softly, and a stream trickles nearby.",
        "Visualize a mountain peak. The air is crisp, the sky is clear, and you feel a deep sense of peace and accomplishment."
    };

    private static readonly string[] Prompts =
    {
        "Take a deep breath and feel the warmth of the sun on your skin...",
        "Listen to the sounds of nature around you...",
        "Feel the calmness and peace filling your mind...",
        "Imagine letting go of all stress and worries...",
        "Embrace the stillness and tranquility of the moment..."
    };

    public VisualizationActivity() : base("Visualization Activity", "Use guided imagery to relax your mind.") { }

    protected override void Execute()
    {
        string scene = Scenes[new Random().Next(Scenes.Length)];
        Console.WriteLine("\n" + scene);
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
            ShowSpinner(5);
        }
        End();
    }
}
