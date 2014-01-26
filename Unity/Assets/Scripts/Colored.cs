using UnityEngine;
//using UnityEditor;
using System.Collections;

public class Colored : MonoBehaviour
{
	public ColoredWorld world = null;

	ColorManager colorManager;

	public ColorName MyColor;

	private Color color;
	public Color Color
	{
		set
		{
			renderer.material.color = color = value;
			//if (world != null)
			//{
			//	float h, s, v;
			//	EditorGUIUtility.RGBToHSV(color, out h, out s, out v);
			//	world.Color = EditorGUIUtility.HSVToRGB(h + .5f, s, v);
			//}
		}
		get
		{
			return color;
		}
	}

	void Start()
	{
		colorManager = FindObjectOfType<ColorManager>();
		if (tag == "Player") SetCombo(colorManager.ColorCombos.Find(item => item.PlayerColor == MyColor));
	}

	public void SetCombo(ColorCombo combo)
	{
		Color = colorManager.ColorCombos.Find(item => item.PlayerColor == combo.Complementary).baseColor;
		colorManager.SetWorldColors(combo);
	}

	//public Color Blend(Colored other)
	//{
	//	float h1, s1, v1, h2, s2, v2;
	//	EditorGUIUtility.RGBToHSV(color, out h1, out s1, out v1);
	//	EditorGUIUtility.RGBToHSV(other.color, out h2, out s2, out v2);
	//	return EditorGUIUtility.HSVToRGB(
	//		(h1 + h2) / 2,
	//		(s1 + s2) / 2,
	//		(v1 + v2) / 2);
	//}

	//public static Color RandomColor()
	//{
	//	return EditorGUIUtility.HSVToRGB(Random.value, Random.value, Random.value);
	//}
}
