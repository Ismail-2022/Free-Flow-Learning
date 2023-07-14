using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;

public class ObjectGrabber : MonoBehaviour
{
    public float grabDistance = 0.2f;
    public LayerMask grabMask;
    public UnityEvent onGrab;

    private OVRHand m_hand;
    private GameObject m_grabbedObject;
    private Grabbable m_grabbable;

    private void Awake()
    {
        m_hand = GetComponent<OVRHand>();
    }

    private void Update()
    {
        if (m_grabbedObject == null)
        {
            if (m_hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && m_hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, grabMask))
                {
                    m_grabbedObject = hit.collider.gameObject;
                    m_grabbable = m_grabbedObject.GetComponent<Grabbable>();
                    m_grabbable.GrabBegin(this);
                    onGrab.Invoke();
                }
            }
        }
        else
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0.1f)
            {
                m_grabbable.GrabEnd();
                m_grabbedObject = null;
            }
        }
    }
}
