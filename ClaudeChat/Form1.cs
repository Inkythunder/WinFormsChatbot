using ClaudeChat.Services;

namespace ClaudeChat;

public partial class Form1 : Form
{
    private readonly List<ChatTurn> _history = new();

    private readonly ClaudeClient _client;

    private static readonly Color UserColour = Color.FromArgb(0, 92, 180);
    private static readonly Color ClaudeColour = Color.FromArgb(110, 50, 160);
    private static readonly Color ErrorColour = Color.FromArgb(190, 30, 30);

    public Form1(string apiKey)
    {
        InitializeComponent();
        _client = new ClaudeClient(apiKey);
    }

    private async void sendButton_Click(object sender, EventArgs e)
    {
        await SendAsync();
    }

    private async Task SendAsync()
    {
        var text = inputBox.Text.Trim();
        if (text.Length == 0) return;

        inputBox.Clear();
        SetBusy(true);

        AppendMessage("You", text, UserColour);
        _history.Add(new ChatTurn("user", text));

        try
        {
            var reply = await _client.SendAsync(_history);

            _history.Add(new ChatTurn("assistant", reply));
            AppendMessage("Claude", reply, ClaudeColour);
        }
        catch (ClaudeApiException ex)
        {
            _history.RemoveAt(_history.Count - 1);
            AppendMessage("Error", $"API error {ex.StatusCode} ({ex.ErrorType ?? "unknown"}): {ex.Message}", ErrorColour);
        }
        catch (HttpRequestException ex)
        {
            _history.RemoveAt(_history.Count - 1);
            AppendMessage("Error", $"Network error: {ex.Message}", ErrorColour);
        }
        catch (TaskCanceledException)
        {
            _history.RemoveAt(_history.Count - 1);
            AppendMessage("Error", "The request times out.", ErrorColour);
        }
        finally
        {
            SetBusy(false);
            inputBox.Focus();
        }
    }

    private void SetBusy(bool busy)
    {
        busyBar.Visible = busy;
        sendButton.Enabled = !busy;
        inputBox.Enabled = !busy;
        UseWaitCursor = busy;
    }

    private void AppendMessage(string label, string text, Color labelColour)
    {
        BeginMessage(label, labelColour);
        AppendText(text);
        EndMessage();
    }

    private void BeginMessage(string label, Color labelColour)
    {
        historyBox.SelectionStart = historyBox.TextLength;
        historyBox.SelectionLength = 0;

        historyBox.SelectionFont = new Font(historyBox.Font, FontStyle.Bold);
        historyBox.SelectionColor = labelColour;
        historyBox.AppendText(label + Environment.NewLine);

        historyBox.SelectionFont = historyBox.Font;
        historyBox.SelectionColor = historyBox.ForeColor;
    }

    private void AppendText(string text)
    {
        historyBox.AppendText(text);
        historyBox.ScrollToCaret();
    }

    private void EndMessage()
    {
        historyBox.AppendText(Environment.NewLine + Environment.NewLine);
        historyBox.ScrollToCaret();
    }

    private void inputBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Makes enter send instead of making a new line
        if (e.KeyCode == Keys.Enter && !e.Shift)
        {
            e.SuppressKeyPress = true;
            sendButton.PerformClick();
        }
    }
}
