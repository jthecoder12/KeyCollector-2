namespace KeyCollector_2.Engine.SceneManagement
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();
        private static Scene? currentScene;

        public static Scene AddScene(Scene scene)
        {
            if (!scenes.Contains(scene)) scenes.Add(scene);

            return scene;
        }

        public static void Dispose()
        {
            currentScene = null;
            foreach (Scene scene in scenes) scene.Dispose();
        }

        public static Scene SetCurrentScene(Scene scene)
        {
            if (scenes.Contains(scene)) currentScene = scene;

            if(!scene.alreadyInit)
            {
                scene.Init();
                scene.alreadyInit = true;
            }

            return scene;
        }

        public static void Render(float dt)
        {
            if (currentScene is not null) currentScene.Render(dt);
        }
    }
}
