using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private ObjectGrabber m_grabber;

    public void GrabBegin(ObjectGrabber grabber)
    {
        m_grabber = grabber;
    }

    public void GrabEnd()
    {
        m_grabber = null;
    }
}
