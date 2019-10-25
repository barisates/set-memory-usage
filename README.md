# set-memory-usage
Set up memory usage to test Pods auto scaling on Kubernetes.

![](https://img.shields.io/github/stars/barisates/set-memory-usage.svg) ![](https://img.shields.io/github/forks/barisates/set-memory-usage.svg) ![](https://img.shields.io/github/issues/barisates/set-memory-usage.svg)

#### Intro

Automatically scale our Pods to maintain performance and minimize cost. Use metrics to determine when to autoscale the deployment on Kubernetes. With this app you can test your auto scaling settings by adjusting your memory usage.

#### Usage

`api/memory` Reset the application's memory usage.

`api/memory/get` View the memory usage of the application.

`api/memory/{MEMORY}` Set the application's memory usage. `{MEMORY}` The value to be set in megabytes.

------------
#### Author

**Barış Ateş**
 - http://barisates.com
 - [github/barisates](https://github.com/barisates "github/barisates")
