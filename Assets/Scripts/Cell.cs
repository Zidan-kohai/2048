using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell Up;
    public Cell Right;
    public Cell Down;
    public Cell Left;

    public Fill fill;
    private void OnEnable()
    {
        GameManager.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameManager.slide -= OnSlide;
    }

    private void OnSlide(string input)
    {
        Debug.Log(input);
        if(input == "w")
        {
            if(Up != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideUp(currentCell);
        }
        if (input == "d")
        {
            if (Right != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideRight(currentCell);
        }
        if (input == "s")
        {
            if (Down != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideDown(currentCell);
        }
        if (input == "a")
        {
            if (Left != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideLeft(currentCell);

        }

        GameManager.ticker++;

        if(GameManager.ticker == 5) 
        {
            GameManager.instance.SpawnFill();
        }
    }

    private void SlideUp(Cell currentCell) 
    {
        if(currentCell.Down == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.Down;
            while (nextCell.Down != null && nextCell.fill == null)
            {
                nextCell = nextCell.Down;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.Down.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.Down.transform;
                    currentCell.Down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Down;
            while (nextCell.Down != null && nextCell.fill == null)
            {
                nextCell = nextCell.Down;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
            }
        }

        if(currentCell.Down == this)
        {
            return;
        }
        SlideUp(currentCell.Down);
    }
    private void SlideRight(Cell currentCell)
    {
        if (currentCell.Left == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.Left;
            while (nextCell.Left != null && nextCell.fill == null)
            {
                nextCell = nextCell.Left;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.Left.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.Left.transform;
                    currentCell.Left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Left;
            while (nextCell.Left != null && nextCell.fill == null)
            {
                nextCell = nextCell.Left;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
            }
        }

        if (currentCell.Left == this)
        {
            return;
        }
        SlideRight(currentCell.Left);
    }
    private void SlideDown(Cell currentCell)
    {
        if (currentCell.Up == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.Up;
            while (nextCell.Up != null && nextCell.fill == null)
            {
                nextCell = nextCell.Up;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.Up.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.Up.transform;
                    currentCell.Up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Up;
            while (nextCell.Up != null && nextCell.fill == null)
            {
                nextCell = nextCell.Up;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
            }
        }

        if (currentCell.Up == this)
        {
            return;
        }
        SlideDown(currentCell.Up);
    }
    private void SlideLeft(Cell currentCell)
    {
        if (currentCell.Right == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.Right;
            while (nextCell.Right != null && nextCell.fill == null)
            {
                nextCell = nextCell.Right;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.Right.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.Right.transform;
                    currentCell.Right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.Right;
            while (nextCell.Right != null && nextCell.fill == null)
            {
                nextCell = nextCell.Right;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
            }
        }

        if (currentCell.Right == this)
        {
            return;
        }
        SlideLeft(currentCell.Right);
    }
}
