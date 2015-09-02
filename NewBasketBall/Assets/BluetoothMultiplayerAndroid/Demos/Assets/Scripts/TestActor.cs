using UnityEngine;

// A very simple object. Moves to the position of the touch
public class TestActor : MonoBehaviour {
    private Vector3 _destination;

    private void Start() {
        _destination = transform.position;

        renderer.material.color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }

    private void Update() {
        if (networkView.isMine) {
            _destination.y = 0f;
            Vector3 direction = _destination - transform.position;

            if (direction.magnitude > 1f)
                transform.Translate(direction.normalized * 70f * Time.deltaTime);

            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo)) {
                    _destination = hitInfo.point;
                }
            }
        }
    }

    private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
        // Serialize the position and color
        if (stream.isWriting) {
            Vector3 position = transform.position;
            Color color = renderer.material.color;

            stream.Serialize(ref position);
            stream.Serialize(ref color.r);
            stream.Serialize(ref color.g);
            stream.Serialize(ref color.b);
            stream.Serialize(ref color.a);
        } else {
            Vector3 position = Vector3.zero;
            Color color = Color.white;

            stream.Serialize(ref position);
            stream.Serialize(ref color.r);
            stream.Serialize(ref color.g);
            stream.Serialize(ref color.b);
            stream.Serialize(ref color.a);

            transform.position = position;
            renderer.material.color = color;
        }
    }
}