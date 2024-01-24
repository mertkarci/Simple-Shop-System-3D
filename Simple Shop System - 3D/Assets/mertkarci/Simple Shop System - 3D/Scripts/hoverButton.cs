using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class hoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Vector3 normalScale;
    private Vector3 hoverScale;
    public float scaleMultiplier = 1.1f;
    private Transform buttonTransform;
    private AudioSource audioSourceHover;
    private AudioSource audioSourceClick;
    private void Start()
    {

        buttonTransform = GetComponent<Transform>();
        normalScale = buttonTransform.localScale;
        audioSourceHover = GameObject.Find("HoverSound").GetComponent<AudioSource>();
        audioSourceClick = GameObject.Find("ClickSound").GetComponent<AudioSource>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverScale = normalScale * scaleMultiplier;
        buttonTransform.localScale = hoverScale;
        if (audioSourceHover != null)
        {
            audioSourceHover.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    
        buttonTransform.localScale = normalScale;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (audioSourceClick != null)
        {
            audioSourceClick.Play();
        }
    }
}