using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Library : MonoBehaviour
{
    public GameObject btnObject;
    public GameObject canvasObject;

    public TextMeshProUGUI libraryTitle;
    public Image libraryImage;
    public TextMeshProUGUI libraryDesc;
    //public GameObject recipeImage;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GlobalVariable.arrayLibrary.GetLength(0); i++)
        {   Debug.Log("getlength:"+GlobalVariable.arrayLibrary.GetLength(0));
            GameObject myObj = Instantiate(btnObject, new Vector2(0, 0), Quaternion.identity); //instantiate button object (the prefab)
            Button myObjButton = myObj.GetComponent<Button>(); //then get the button
            int iCopy = i;
            myObjButton.onClick.AddListener(() => OpenLibrary(iCopy)); //to add listener that has openLibrary in it
            Debug.Log("Listener added " + iCopy);

            myObj.transform.parent = canvasObject.transform;
            myObj.transform.localScale = new Vector3(1, 1, 1);

            TextMeshProUGUI myObjNameText = myObj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>(); //get text of myobj 
            myObjNameText.text = GlobalVariable.arrayLibraryButton[i, 0]; //then set it to arrayLibraryButton

            Image myObjImage = myObj.transform.Find("Image").GetComponent<Image>(); //get myojb image
            myObjImage.sprite = Resources.Load<Sprite>(GlobalVariable.arrayLibraryButton[i, 1]); //then set to arrayLibraryButton 

        }
    }

    void OpenLibrary(int j)
    {
        libraryImage.gameObject.SetActive(true);
        libraryTitle.text = GlobalVariable.arrayLibrary[j, 0];
        libraryImage.sprite = Resources.Load<Sprite>(GlobalVariable.arrayLibrary[j, 1]);
        libraryDesc.text = GlobalVariable.arrayLibrary[j, 2];
        Debug.Log("Library opened");
    }
   
   
}
