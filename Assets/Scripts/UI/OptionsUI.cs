using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    public static OptionsUI Instance {  get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;

    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;

    [SerializeField] private Transform pressToRebindKeyTransform;


    private void Awake() {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() => {
            SoundManager.instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() => {
            MusicManager.instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() => {
            Hide();
        });

        moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.InteractAlternate); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
    }

    private void Start() {
        KitchenGameManager.instance.OnGamePaused += Instance_OnGamePaused;

        UpdateVisual();

        HidePressToRebind();
        Hide();
    }

    private void Instance_OnGamePaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void UpdateVisual() {
        soundEffectsText.text = "Sound Effects:" + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music:" + Mathf.Round(MusicManager.instance.GetVolume() * 10f);

        moveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebind() {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebind() {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding) {
        ShowPressToRebind();
        GameInput.instance.RebindBinding(binding, () => {
            HidePressToRebind();
            UpdateVisual();
        });
    }
}
