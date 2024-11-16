using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MaintainChildScale : MonoBehaviour
{
    private Vector3 originalScale;
    private Transform parentTransform;

    void Start()
    {
        // Guardar la escala original del objeto
        originalScale = transform.localScale;

        // Obtener el transform del padre
        parentTransform = transform.parent;
    }

    void Update()
    {
        // Detectar si ha habido un cambio en la rotación
        if (transform.hasChanged)
        {
            // Restaurar la escala original adaptada a la escala del padre
            ReadjustScale();
            transform.hasChanged = false; // Resetear el flag de cambio
        }
    }

    private void ReadjustScale()
    {
        if (parentTransform != null)
        {
            // Recalcular la escala del hijo basándola en la escala del padre
            Vector3 parentScale = parentTransform.localScale;
            transform.localScale = new Vector3(
                originalScale.x / parentScale.x,
                originalScale.y / parentScale.y,
                originalScale.z / parentScale.z
            );
        }
        else
        {
            // Si no hay un padre, mantener la escala original
            transform.localScale = originalScale;
        }
    }
}
