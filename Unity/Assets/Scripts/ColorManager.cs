using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ColorName
{
	Red, Yellow, Blue, Green, Orange, Purple, Beige, Greyish, DarkGreen, YellowGreen, Turquoise
}

[System.Serializable]
public class ColorCombo
{
	public ColorName PlayerColor;
	public ColorName Complementary;
	public Color baseColor;
	public Color shade1;
	public Color shade2;
	public Color shade3;
	public Color shade4;
}

public class ColorManager : MonoBehaviour
{
	[SerializeField]
	public List<ColorCombo> ColorCombos;

	// Use this for initialization
	void Start()
	{

	}

	public void SetWorldColors(ColorCombo combo)
	{
		foreach(Renderer r in GameObject.FindGameObjectWithTag("PlatformCollector").GetComponentsInChildren<Renderer>())
		{
			r.material.color = combo.shade1;
		}

		foreach (Renderer r in GameObject.FindGameObjectWithTag("CrossCollector").GetComponentsInChildren<Renderer>())
		{
			r.material.color = combo.shade2;
		}

		GameObject.FindGameObjectWithTag("Background").renderer.material.color = combo.shade3;

		ColorCombo complementary = ColorCombos.Find(item => item.PlayerColor == combo.Complementary);

		foreach (Renderer r in GameObject.FindGameObjectWithTag("HeartCollector").GetComponentsInChildren<Renderer>())
		{
			r.material.color = complementary.baseColor;
		}

		foreach (Renderer r in GameObject.FindGameObjectWithTag("SpikeCollector").GetComponentsInChildren<Renderer>())
		{
			r.material.color = complementary.shade1;
		}
	}
}
