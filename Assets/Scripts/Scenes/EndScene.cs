using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private GameObject _black, _white;
    [SerializeField] private Transform _blackTarget, _whiteTarget;
    [SerializeField]
    private Image _end, en;

    public IEnumerator StartScene()
    {
        AudioManager.Instance.PlayEnding();
        float t = 0;     

        _white.GetComponent<Animator>().SetTrigger("IsIdle");
        _black.GetComponent<Animator>().SetTrigger("IsIdle");

        yield return new WaitForSeconds(1.5f);

        _white.GetComponent<Animator>().SetTrigger("WalkRight");
        _black.GetComponent<Animator>().SetTrigger("WalkRight");

        while (t < 0.045f)
        {
            float blackX = Mathf.Lerp(_black.transform.position.x, _blackTarget.position.x, t);
            float whiteX = Mathf.Lerp(_white.transform.position.x, _whiteTarget.position.x, t);            

            _black.transform.position = new Vector3(blackX, _blackTarget.position.y, _blackTarget.position.z);
            _white.transform.position = new Vector3(whiteX, _whiteTarget.position.y, _whiteTarget.position.z);

            t += 0.0002f;
            yield return new WaitForFixedUpdate();
        }

        _white.GetComponent<Animator>().SetTrigger("Ending");
        _black.GetComponent<Animator>().SetTrigger("Ending");


        yield return new WaitForSeconds(0.5f);
        t = 0;
        while(t < 1)
        {
            _end.color = new Color(_end.color.r, _end.color.g, _end.color.b, t);
            en.color = new Color(en.color.r, en.color.g, en.color.b, t);

            t += 0.02f;
            yield return new WaitForFixedUpdate();
        }
    }
}
