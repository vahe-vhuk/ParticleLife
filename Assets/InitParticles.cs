using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.Collections;


public class InitParticles : MonoBehaviour
{
    [SerializeField] private GameObject RedParticle;
    [SerializeField] private GameObject BlueParticle;
    [SerializeField] private GameObject GreenParticle;
    [SerializeField] public int count;

    public static KDTree<GameObject> list = new KDTree<GameObject>(2);
    private static KDTree<GameObject> tmplist = new KDTree<GameObject>(2);


    void Start()
    {
        for (var i = 0; i < count / 3; ++i)
        {
            var tmp = Instantiate(RedParticle);
			double[] p1 = new double[2]{Random.Range(Config.w, Config.width), Random.Range(Config.h, Config.height)};
            tmp.transform.position = new Vector2((float)p1[0], (float)p1[1]);
            list.Add(p1, tmp);
            
            tmp = Instantiate(BlueParticle);
            p1 = new double[2]{Random.Range(Config.w, Config.width), Random.Range(Config.h, Config.height)};
            tmp.transform.position = new Vector2((float)p1[0], (float)p1[1]);
            list.Add(p1, tmp);
            
            tmp = Instantiate(GreenParticle);
            p1 = new double[2]{Random.Range(Config.w, Config.width), Random.Range(Config.h, Config.height)};
            tmp.transform.position = new Vector2((float)p1[0], (float)p1[1]);
            list.Add(p1, tmp);

			

        }
        

        
        
    }

    void Update()
    {
        Vector3 step;
        Vector3 pos;
        Vector3 tmp;
        foreach (var obj in list)
        {
            pos = obj.Value.transform.position;
            step = new Vector3(0, 0, 0);


			foreach (var i in list.Nearest(new double[]{ pos.x, pos.y }, Config.radius))
            {
                tmp = pos - i.Node.Value.transform.position;

                if (tmp.magnitude < 4 && Config.conf[obj.Value.tag + i.Node.Value.tag] > 0) {
					i.Node.Value.GetComponent<ParticleMove>().dir = Vector3.zero;
					continue;
				};
                
				Vector3 dir = Config.conf[obj.Value.tag + i.Node.Value.tag] * (tmp / (tmp.magnitude * tmp.magnitude + 1));

				i.Node.Value.GetComponent<ParticleMove>().dir = dir;

				i.Node.Value.GetComponent<ParticleMove>().move();

				//obj.Value.GetComponent<ParticleMove>().dir = -dir;
				//obj.Value.GetComponent<ParticleMove>().move();

            	tmplist.Add(new double[2] {i.Node.Value.transform.position.x, i.Node.Value.transform.position.y }, obj.Value);
                
            }


        	
			list = tmplist;
        	tmplist = new KDTree<GameObject>(2);


        }

    }
}
